﻿using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Application.Service;
using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Core.Enums;
using _4Lab.Occurrences.Application.DTOs;
using _4Lab.Occurrences.Domain.Interfaces;
using _4Lab.Orchestrator.DTOs.Inputs;
using _4Lab.Orchestrator.DTOs.Response;
using _4Lab.Orchestrator.Filters;
using _4Lab.Orchestrator.Interfaces;
using Api.Rnc.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OccurrenceRegisterController : ControllerBase
    {
        private readonly IOccurrenceRegisterRepository _occurrenceRegisterRepository;
        private readonly IMapper _mapper;
        private readonly ICreateOccurrenceRegisterFacade _createOccurrenceRegisterFacade;
        private readonly IGetOccurrenceRegisterByIdFacade _getOccurrenceRegisterByIdFacade;
        private readonly IOccurrenceRegisterClassificationRepository _occurrenceClassificationRepository;
        private readonly IOccurrenceRegisterTypeRepository _occurrenceRegisterTypeRepository;
        private readonly IOccurrenceAppService _occurrenceAppService;
        private readonly IGetOccurrenceRegisterAll _getOccurrenceRegisterAll;

        public OccurrenceRegisterController(IOccurrenceRegisterRepository occurrenceRegisterRepository
                                           , IMapper mapper
                                           , ICreateOccurrenceRegisterFacade createOccurrenceRegisterFacade
                                           , IGetOccurrenceRegisterByIdFacade getOccurrenceRegisterByIdFacade
                                           , IOccurrenceRegisterClassificationRepository occurrenceClassificationRepository
                                           , IOccurrenceRegisterTypeRepository occurrenceRegisterTypeRepository
                                           , IOccurrenceAppService occurrenceAppService
                                           , IGetOccurrenceRegisterAll getOccurrenceRegisterAll)
        {
            _occurrenceRegisterRepository = occurrenceRegisterRepository;
            _mapper = mapper;
            _createOccurrenceRegisterFacade = createOccurrenceRegisterFacade;
            _getOccurrenceRegisterByIdFacade = getOccurrenceRegisterByIdFacade;
            _occurrenceClassificationRepository = occurrenceClassificationRepository;
            _occurrenceRegisterTypeRepository = occurrenceRegisterTypeRepository;
            _occurrenceAppService = occurrenceAppService;
            _getOccurrenceRegisterAll = getOccurrenceRegisterAll;
        }

        /// <summary>
        /// Endpoint responsável por inserir um registro de não conformidade.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] DtoOccurrenceRegisteFacaderInput input)
        {
            try
            {
                input.UserId = User.GetUserId();
                input.UserName = User.GetUserName();

                if (await _createOccurrenceRegisterFacade.Execute(input))
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Endpoint responsável por trazer as não conformidades registradas
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(typeof(IQueryable<DtoOccurrenceRegisterFacadeResponse>), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.ResponsibleFS) + "," + nameof(UserPermissionType.QualityAnalist) + "," + nameof(UserPermissionType.ResponsibleT))]
        public async Task<IActionResult> GetAll([FromQuery] DtoOccurrenceRegisterFilter filter)
        {
            var nonComplianceRegisters = await _occurrenceRegisterRepository
                .GetAllWithIncludes();
            var result = await _getOccurrenceRegisterAll.Execute(_mapper.ProjectTo<DtoOccurrenceRegisterResponse>(nonComplianceRegisters
                             .OccurenceFilterByAnalyse(filter.AnalyseFilter)
                             .OccurrenceFilterByPending(filter.PendingFilter)));
                            
            result = result.OccurrenceFilterByPendingDelayed(filter.IsDelayed)
                           .OrderByDescending(x=>x.IsDelayed)
                           .ThenByDescending(x=>x.Date)
                           .ThenByDescending(x=>x.CanVerifyEffectiveness);

            return Ok(result);
        }

        /// <summary>
        /// Endpoint responsável por trazer as não conformidades registradas por data e setor
        /// </summary>
        /// <param name="date"></param>
        /// <param name="setor"></param>
        /// <returns></returns>
        [HttpGet("{date:DateTime}/{setor:required}")]
        [ProducesResponseType(typeof(IQueryable<DtoOccurrenceRegisterFacadeResponse>), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.ResponsibleFS) + "," + nameof(UserPermissionType.QualityAnalist) + "," + nameof(UserPermissionType.ResponsibleT))]
        public async Task<IActionResult> GetAllByDateAndSetor(DateTime date, SetorType setor)
        {
            var nonComplianceRegisters = await _occurrenceRegisterRepository
                .GetAllWithIncludes(nameof(OccurrenceRegister.Setor));
            var registros = await _getOccurrenceRegisterAll.Execute(_mapper.ProjectTo<DtoOccurrenceRegisterResponse>(nonComplianceRegisters));
            return Ok(registros
                .OrderBy(x => x.Id)
                .Where(x => x.Setor == setor.ToString() &&
                       x.Date.Date == date.Date));
        }

        /// <summary>
        /// Endpoint responsável por trazer as não conformidades registradas por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DtoOccurrenceRegisterFacadeResponse), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.ResponsibleFS) + "," + nameof(UserPermissionType.QualityAnalist) + "," + nameof(UserPermissionType.ResponsibleT))]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _getOccurrenceRegisterByIdFacade.Execute(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Endpoint responsável por trazer as classificações de registro de ocorrencia
        /// </summary>
        /// <returns></returns>
        [HttpGet("Classifications")]
        [ProducesResponseType(typeof(IQueryable<DtoOcurrenceClassification>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClassifications()
        {
            return Ok(_mapper.ProjectTo<DtoOcurrenceClassification>(await _occurrenceClassificationRepository.GetAll()));
        }
        /// <summary>
        /// Endpoint responsável por trazer os tipos de registro de ocorrencia
        /// </summary>
        /// <returns></returns>
        [HttpGet("Types")]
        [ProducesResponseType(typeof(IQueryable<DtoOccurrenceType>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOccurrenceTypes()
        {
            return Ok(_mapper.ProjectTo<DtoOccurrenceType>(await _occurrenceRegisterTypeRepository.GetAll()));
        }

        /// <summary>
        /// Endpoint responsável por deletar registros de ocorrencia
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteOccurrenceRegister(Guid id)
        {
            try
            {
                await _occurrenceAppService.DeleteOccurrenceRegister(id);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

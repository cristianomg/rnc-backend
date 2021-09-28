using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Core.Enums;
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

        public OccurrenceRegisterController(IOccurrenceRegisterRepository occurrenceRegisterRepository
                                           , IMapper mapper
                                           , ICreateOccurrenceRegisterFacade createOccurrenceRegisterFacade
                                           , IGetOccurrenceRegisterByIdFacade getOccurrenceRegisterByIdFacade)
        {
            _occurrenceRegisterRepository = occurrenceRegisterRepository;
            _mapper = mapper;
            _createOccurrenceRegisterFacade = createOccurrenceRegisterFacade;
            _getOccurrenceRegisterByIdFacade = getOccurrenceRegisterByIdFacade;
        }

        /// <summary>
        /// Endpoint responsável por inserir um registro de não conformidade.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DtoOccurrenceRegisterResponse), StatusCodes.Status201Created)]
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
        [HttpGet("all/{analyseFilter}/{pendingFilter}")]
        [ProducesResponseType(typeof(IQueryable<DtoOccurrenceRegisterResponse>), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.ResponsibleFS) + "," + nameof(UserPermissionType.QualityAnalist) + "," + nameof(UserPermissionType.ResponsibleT))]
        public async Task<IActionResult> GetAll(AnalyseFilter analyseFilter = AnalyseFilter.All
                                              , PendingFilter pendingFilter = PendingFilter.All)
        {
            var nonComplianceRegisters = await _occurrenceRegisterRepository
                .GetAllWithIncludes(nameof(OccurrenceRegister.Setor));

            return Ok(_mapper.ProjectTo<DtoOccurrenceRegisterResponse>(nonComplianceRegisters
                             .OccurenceFilterByAnalyse(analyseFilter)
                             .OccurrenceFilterByPending(pendingFilter)
                             .OrderBy(x => x.RootCauseAnalysis != null)
                             .ThenBy(x => x.Id)));
        }

        /// <summary>
        /// Endpoint responsável por trazer as não conformidades registradas por data e setor
        /// </summary>
        /// <param name="date"></param>
        /// <param name="setor"></param>
        /// <returns></returns>
        [HttpGet("{date:DateTime}/{setor:required}")]
        [ProducesResponseType(typeof(IQueryable<DtoOccurrenceRegisterResponse>), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.ResponsibleFS) + "," + nameof(UserPermissionType.QualityAnalist) + "," + nameof(UserPermissionType.ResponsibleT))]
        public async Task<IActionResult> GetAllByDateAndSetor(DateTime date, SetorType setor)
        {
            var nonComplianceRegisters = await _occurrenceRegisterRepository
                .GetAllWithIncludes(nameof(OccurrenceRegister.Setor));

            return Ok(_mapper.ProjectTo<DtoOccurrenceRegisterResponse>(nonComplianceRegisters
                              .OrderBy(x => x.Id)
                              .Where(x => x.SetorId == setor && 
                                     x.RegisterDate.Year == date.Year && 
                                     x.RegisterDate.Month == date.Month &&
                                     x.RootCauseAnalysis != null))
                     );
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
            return Ok(await _getOccurrenceRegisterByIdFacade.Execute(id));
        }

    }
}

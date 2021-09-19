using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Application.Service;
using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.WebApi.Extensions;
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
    public class NonComplianceRegisterController : ControllerBase
    {
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IMapper _mapper;
        private readonly IOcurrenceAppService _ocurrenceAppService;

        public NonComplianceRegisterController(INonComplianceRegisterRepository nonComplianceRegisterRepository, IMapper mapper, IOcurrenceAppService ocurrenceAppService)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _mapper = mapper;
            _ocurrenceAppService = ocurrenceAppService;
        }

        /// <summary>
        /// Endpoint responsável por inserir um registro de não conformidade.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DtoNonComplianceRegisterResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] DtoNonComplianceRegisterInput dto)
        {
            try
            {
                dto.UserId = User.GetUserId();
                dto.UserName = User.GetUserName();

                var responseService = await _ocurrenceAppService.CreateNonComplianceRegister(dto);
                if (responseService)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint responsável por trazer as não conformidades por setor do usuário logado
        /// </summary>
        /// <returns></returns>
        [HttpGet("setor/{setor}")]
        [HttpGet("setor/{setor}/{hasRootCauseAnalysis}")]
        [ProducesResponseType(typeof(IQueryable<DtoNonComplianceRegisterResponse>), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.Supervisor) + "," + nameof(UserPermissionType.QualityBiomedical))]
        public async Task<IActionResult> GetAllBySetor(SetorType setor, HasRootCauseAnalysisType hasRootCauseAnalysis = HasRootCauseAnalysisType.All)
        {
            var nonComplianceRegisters = await _nonComplianceRegisterRepository.GetAllWithIncludes(nameof(NonComplianceRegister.Setor));

            return Ok(_mapper.ProjectTo<DtoNonComplianceRegisterResponse>(nonComplianceRegisters
                    .FilterByHasRootCauseAnalysis(hasRootCauseAnalysis)
                    .Where(x => x.SetorId == setor)
                    .OrderBy(x => x.RootCauseAnalysis != null)
                    .ThenBy(x => x.Id)));
        }

        /// <summary>
        /// Endpoint responsável por trazer as não conformidades registradas
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [HttpGet("all/{hasRootCauseAnalysis}")]
        [ProducesResponseType(typeof(IQueryable<DtoNonComplianceRegisterResponse>), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.Supervisor) + "," + nameof(UserPermissionType.QualityBiomedical))]
        public async Task<IActionResult> GetAll(HasRootCauseAnalysisType hasRootCauseAnalysis = HasRootCauseAnalysisType.All)
        {
            var nonComplianceRegisters = await _nonComplianceRegisterRepository
                .GetAllWithIncludes(nameof(NonComplianceRegister.Setor));

            return Ok(_mapper.ProjectTo<DtoNonComplianceRegisterResponse>(nonComplianceRegisters
                .FilterByHasRootCauseAnalysis(hasRootCauseAnalysis)
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
        [ProducesResponseType(typeof(IQueryable<DtoNonComplianceRegisterResponse>), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.Supervisor) + "," + nameof(UserPermissionType.QualityBiomedical))]
        public async Task<IActionResult> GetAllByDateAndSetor(DateTime date, SetorType setor)
        {
            var nonComplianceRegisters = await _nonComplianceRegisterRepository
                .GetAllWithIncludes(nameof(NonComplianceRegister.Setor));

            return Ok(_mapper.ProjectTo<DtoNonComplianceRegisterResponse>(nonComplianceRegisters.OrderBy(x => x.Id).Where(x => x.SetorId == setor && x.RegisterDate.Year == date.Year
            && x.RegisterDate.Month == date.Month && x.RootCauseAnalysis != null)));
        }

        /// <summary>
        /// Endpoint responsável por trazer as não conformidades registradas por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DtoNonComplianceRegisterResponse), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(UserPermissionType.Supervisor) + "," + nameof(UserPermissionType.QualityBiomedical))]
        public async Task<IActionResult> GetById(int id)
        {
            var nonComplianceRegister = await _ocurrenceAppService.GetNonComplieanceRegisterById(id);
            return Ok(nonComplianceRegister);
        }

    }
}

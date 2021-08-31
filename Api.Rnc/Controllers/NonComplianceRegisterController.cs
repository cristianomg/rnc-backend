using Api.Rnc.Extensions;
using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Util.Extensions;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NonComplianceRegisterController : ControllerBase
    {
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IMapper _mapper;
        private readonly ICreateNonComplianceRegisterService _createNonComplianceRegisterService;
        private readonly IGetNonComplieanceRegisterByIdService _getNonComplianceRegisterByIdService;
        public NonComplianceRegisterController(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                                               IMapper mapper,
                                               ICreateNonComplianceRegisterService createNonComplianceRegisterService,
                                               IGetNonComplieanceRegisterByIdService getNonComplianceRegisterByIdService)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _mapper = mapper;
            _createNonComplianceRegisterService = createNonComplianceRegisterService;
            _getNonComplianceRegisterByIdService = getNonComplianceRegisterByIdService;
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
            dto.UserId = User.GetUserId();
            dto.UserName = User.GetUserName();

            var responseService = await _createNonComplianceRegisterService.Execute(dto);
            if (responseService.Success)
                return Ok();
            return BadRequest(responseService.Message);
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
            var nonComplianceRegisters = await _nonComplianceRegisterRepository
                .GetAllWithIncludes(nameof(NonComplianceRegister.User), nameof(NonComplianceRegister.Setor));
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
                .GetAllWithIncludes(nameof(NonComplianceRegister.User), nameof(NonComplianceRegister.Setor));
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
                .GetAllWithIncludes(nameof(NonComplianceRegister.User), nameof(NonComplianceRegister.Setor));

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
            var nonComplianceRegister = await _getNonComplianceRegisterByIdService.Execute(id);
            return Ok(nonComplianceRegister.Value);
        }

    }
}

using Api.Rnc.Extensions;
using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Dtos.Responses;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserPermissionType.ResponsibleFS) + "," + nameof(UserPermissionType.AnalystBiomedical))]
    public class AssessNonComplianceController : ControllerBase
    {
        private readonly IRootCauseAnalysisRepository _analyzeRootCauseRepository;
        private readonly ICreateRootCauseAnalysisService _createAnalyzeRootCauseService;
        private readonly IMapper _mapper;
        public AssessNonComplianceController(IRootCauseAnalysisRepository analyzeRootCauseRepository,
                                             ICreateRootCauseAnalysisService createAnalyzeRootCauseService,
                                             IMapper mapper)
        {
            _analyzeRootCauseRepository = analyzeRootCauseRepository;
            _mapper = mapper;
            _createAnalyzeRootCauseService = createAnalyzeRootCauseService;
        }

        /// <summary>
        /// Endpoint responsável por criar a análise de causa raiz
        /// </summary>
        /// <param name="analyze"></param>
        /// <returns></returns>
        [HttpPost("AnalyzeRootCause")]
        public async Task<IActionResult> AnalyzeRootCause([FromBody] DtoRootCauseAnalysisInput analyze)
        {
            analyze.UserId = User.GetUserId();
            analyze.UserName = User.GetUserName();

            var responseService = await _createAnalyzeRootCauseService.Execute(analyze);
            if (responseService.Success)
                return Ok(_mapper.Map<DtoCreateRootCauseAnalysisResponse>(responseService.Value));

            return BadRequest(responseService.Message);
        }
    }
}

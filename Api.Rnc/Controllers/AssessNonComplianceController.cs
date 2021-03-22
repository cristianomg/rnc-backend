using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Services;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserPermissionType.Supervisor) + "," + nameof(UserPermissionType.QualityBiomedical))]
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
        [HttpPost("AnalyzeRootCause")]
        public async Task<IActionResult> AnalyzeRootCause([FromBody] DtoRootCauseAnalysisInput analyze)
        {
            var userId = Convert.ToInt32(User.Claims.First(x => x.Type == "UserId").Value);

            var responseService = await _createAnalyzeRootCauseService.Execute(userId, analyze);
            if (responseService.Success)
                return await Task.FromResult(Ok(responseService.Value));

            return BadRequest(responseService.Message);
        }
    }
}

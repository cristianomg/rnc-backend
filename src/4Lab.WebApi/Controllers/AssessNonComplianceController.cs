using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Application.Service;
using _4lab.Occurrences.Domain.Interfaces;
using _4Lab.Core.DomainObjects.Enums;
using Api.Rnc.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserPermissionType.Supervisor) + "," + nameof(UserPermissionType.QualityBiomedical))]
    public class AssessNonComplianceController : ControllerBase
    {
        private readonly IRootCauseAnalysisRepository _analyzeRootCauseRepository;
        private readonly IMapper _mapper;
        private readonly IOccurrenceAppService _occurrenceAppService;

        public AssessNonComplianceController(IRootCauseAnalysisRepository analyzeRootCauseRepository, IMapper mapper, IOccurrenceAppService occurrenceAppService)
        {
            _analyzeRootCauseRepository = analyzeRootCauseRepository;
            _mapper = mapper;
            _occurrenceAppService = occurrenceAppService;
        }

        /// <summary>
        /// Endpoint responsável por criar a análise de causa raiz
        /// </summary>
        /// <param name="analyze"></param>
        /// <returns></returns>
        [HttpPost("AnalyzeRootCause")]
        public async Task<IActionResult> AnalyzeRootCause([FromBody] DtoRootCauseAnalysisInput analyze)
        {
            try
            {
                analyze.UserId = User.GetUserId();
                analyze.UserName = User.GetUserName();

                var responseService = await _occurrenceAppService.CreateRootCauseAnalysis(analyze);

                if (responseService != null)
                    return Ok(_mapper.Map<DtoCreateRootCauseAnalysisResponse>(responseService));

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

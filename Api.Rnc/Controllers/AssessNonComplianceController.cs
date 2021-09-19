using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Application.Service;
using _4lab.Ocurrences.Domain.Interfaces;
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
        private readonly IOcurrenceAppService _ocurrenceAppService;

        public AssessNonComplianceController(IRootCauseAnalysisRepository analyzeRootCauseRepository, IMapper mapper, IOcurrenceAppService ocurrenceAppService)
        {
            _analyzeRootCauseRepository = analyzeRootCauseRepository;
            _mapper = mapper;
            _ocurrenceAppService = ocurrenceAppService;
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

                var responseService = await _ocurrenceAppService.CreateRootCauseAnalysis(analyze);

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

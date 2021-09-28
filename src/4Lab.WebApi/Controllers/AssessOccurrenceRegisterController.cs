using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Application.Service;
using _4lab.Occurrences.Domain.Interfaces;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Occurrences.Application.DTOs;
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
    [Authorize(Roles = nameof(UserPermissionType.ResponsibleFS) + "," + nameof(UserPermissionType.QualityAnalist) + "," + nameof(UserPermissionType.ResponsibleT))]
    public class AssessOccurrenceRegisterController : ControllerBase
    {
        private readonly IRootCauseAnalysisRepository _analyzeRootCauseRepository;
        private readonly IMapper _mapper;
        private readonly IOccurrenceAppService _occurrenceAppService;

        public AssessOccurrenceRegisterController(IRootCauseAnalysisRepository analyzeRootCauseRepository, IMapper mapper, IOccurrenceAppService occurrenceAppService)
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
        [HttpPost("RootCauseAnalysis")]
        public async Task<IActionResult> AnalyzeRootCause([FromBody] DtoRootCauseAnalysisInput analysis)
        {
            try
            {
                analysis.UserId = User.GetUserId();
                analysis.UserName = User.GetUserName();

                var responseService = await _occurrenceAppService.CreateRootCauseAnalysis(analysis);

                if (responseService)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
   
        [HttpPost("RiskAnalysis")]
        public async Task<IActionResult> RiskAnalysis([FromBody] DtoRiskAnalysisInput analysis)
        {
            try
            {
                analysis.UserId = User.GetUserId();
                analysis.UserName = User.GetUserName();
                var responseService = await _occurrenceAppService.CreateRiskAnalysis(analysis);
                if (responseService)
                    return Ok();

                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

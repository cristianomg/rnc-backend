﻿using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Api.Rnc.Extensions;
using Domain.Dtos.Responses;

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
            var userId = User.GetUserId();

            var responseService = await _createAnalyzeRootCauseService.Execute(userId, analyze);
            if (responseService.Success)
                return Ok(_mapper.Map<DtoCreateRootCauseAnalysisResponse>(responseService.Value));

            return BadRequest(responseService.Message);
        }
    }
}

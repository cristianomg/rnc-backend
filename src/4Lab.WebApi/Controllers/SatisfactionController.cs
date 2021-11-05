﻿using _4Lab.Satisfaction.Application.DTOs;
using _4Lab.Satisfaction.Application.Service;
using _4Lab.Satisfaction.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SatisfactionSurveyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISatisfactionAppService _satisfactionAppService;
        public SatisfactionSurveyController(IMapper mapper, ISatisfactionAppService satisfactionAppService)
        {
            _mapper = mapper;
            _satisfactionAppService = satisfactionAppService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(DtoSatisfactionSurveyInput), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterSatisfactionSurvey([FromBody] DtoSatisfactionSurveyInput dtoSatisfactionSurvey)
        {
            await _satisfactionAppService.RegisterSatisfactionSurvey(dtoSatisfactionSurvey);
            return Ok();
        }
        [HttpGet("all")]
        [ProducesResponseType(typeof(IQueryable<DtoSatisfactionSurveyInput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSatisfactionSurvey()
        {
            var result = await _satisfactionAppService.GetSatisfactionSurveyAll();
            if (result.Any())
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IQueryable<DtoSatisfactionSurveyInput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSatisfactionSurvey(Guid id)
        {
            var result = await _satisfactionAppService.GetSatisfactionSurveyById(id);
            if (result != null)
            {
                return Ok();
            }
            return NoContent();
        }
    }
}

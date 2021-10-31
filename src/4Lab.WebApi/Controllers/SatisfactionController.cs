using _4Lab.Satisfaction.Application.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SatisfactionSurveyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISatisfactionAppService satisfactionAppService;
        public SatisfactionSurveyController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost]
        //[ProducesResponseType(typeof(IQueryable<DtoActionPlainListResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterSatisfactionSurvey()
        {
            return Ok();
        }
        [HttpGet]
        //[ProducesResponseType(typeof(IQueryable<DtoActionPlainListResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSatisfactionSurvey()
        {
            return Ok();
        }
    }
}

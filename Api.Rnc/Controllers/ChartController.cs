using Api.Rnc.Extensions;
using Domain.Dtos.Responses;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly ISendChartToEmailService _sendChartToEmailService;
        private readonly ICreatePieChartWithNonComplianceRegisterService _createPieChartWithNonComplianceRegisterService;
        public ChartController(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                               ISendChartToEmailService sendChartToEmailService,
                               ICreatePieChartWithNonComplianceRegisterService createPieChartWithNonComplianceRegisterService)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _sendChartToEmailService = sendChartToEmailService;
            _createPieChartWithNonComplianceRegisterService = createPieChartWithNonComplianceRegisterService;
        }
        [HttpGet("{setor:required}")]
        public async Task<IActionResult> GetChartBySetor(SetorType setor)
        {
            var createPieChartResponse = await _createPieChartWithNonComplianceRegisterService.Execute(setor);
            if (createPieChartResponse.Success)
                return Ok(Convert.ToBase64String(createPieChartResponse.Value));
            else
                return BadRequest(createPieChartResponse.Message);
        }
        [HttpGet("email/{setor:required}")]
        public async Task<IActionResult> SendEmail(SetorType setor)
        {
            var userId = User.GetUserId();
            var sendChartToEmailResponse = await _sendChartToEmailService.Execute(userId, setor);
            if (sendChartToEmailResponse.Success)
                return Ok();
            else
                return BadRequest(sendChartToEmailResponse.Message);
        }
    }
}

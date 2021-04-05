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
        public ChartController(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                               ISendChartToEmailService sendChartToEmailService)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _sendChartToEmailService = sendChartToEmailService;
        }
        [HttpGet("{setor:required}")]
        public async Task<IActionResult> GetChartBySetor(SetorType setor)
        {
            return Ok(await _nonComplianceRegisterRepository.GetBySetor(setor));
        }
        [HttpGet("email/{setor:required}")]
        public async Task<IActionResult> SendEmail(SetorType setor)
        {
            var teste = await _sendChartToEmailService.Execute(setor);
            return Ok(teste);
        }
    }
}

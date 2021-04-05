using Api.Rnc.Extensions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        /// <summary>
        /// Endpoint responsável por retornar o grafico de registros para o mes e setor informado
        /// </summary>
        /// <param name="setor"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("{setor:required}/{month:range(1, 12)}")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetChartBySetor(SetorType setor, int month)
        {
            var createPieChartResponse = await _createPieChartWithNonComplianceRegisterService.Execute(setor, month);
            if (createPieChartResponse.Success)
                return Ok(Convert.ToBase64String(createPieChartResponse.Value));
            else
                return BadRequest(createPieChartResponse.Message);
        }
        /// <summary>
        /// Endpoint responsável por enviar email contendo o grafico de registros para o mes e setor informado
        /// </summary>
        /// <param name="setor"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("email/{setor:required}/{month:range(1,12)}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendEmail(SetorType setor, int month)
        {
            var userId = User.GetUserId();
            var sendChartToEmailResponse = await _sendChartToEmailService.Execute(userId, setor, month);
            if (sendChartToEmailResponse.Success)
                return Ok();
            else
                return BadRequest(sendChartToEmailResponse.Message);
        }
    }
}

using _4lab.Administration.Application.Service;
using _4lab.Infrastructure.Smtp;
using _4lab.Ocurrences.Application.Service;
using _4Lab.Administration.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using Api.Rnc.Extensions;
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
        private readonly IOcurrenceAppService _ocurrenceAppService;
        private readonly IUserAppService _userAppService;
        private readonly IEmailSender _senderEmail;

        public ChartController(IOcurrenceAppService ocurrenceAppService, IUserAppService userAppService, IEmailSender senderEmail)
        {
            _ocurrenceAppService = ocurrenceAppService;
            _userAppService = userAppService;
            _senderEmail = senderEmail;
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
            try
            {
                var createPieChartResponse = await _ocurrenceAppService.CreatePieChartWithNonComplianceRegister(setor, month);

                if (createPieChartResponse != null && createPieChartResponse.Length > 0)
                    return Ok(Convert.ToBase64String(createPieChartResponse));

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

            var user = await _userAppService.GetUserByIdWithInclude(userId, nameof(UserAuth));

            if (user == null)
                throw new Exception("Usuário não encontrado.");

            var chart = await _ocurrenceAppService.CreatePieChartWithNonComplianceRegister(setor, month);

            var template = "<p>O grafico está anexado.</p>";

            await _senderEmail.SendEmail(user.UserAuth.Email, template, "Grafico", chart, "Gráfico", true);

            return Ok();
        }
    }
}

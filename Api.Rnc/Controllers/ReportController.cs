using _4lab.Administration.Application.Service;
using _4lab.Infrastructure.Smtp;
using _4lab.Ocurrences.Application.Service;
using _4Lab.Core.DomainObjects.Enums;
using Api.Rnc.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Util.GeneratePDF;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserPermissionType.QualityBiomedical))]
    public class ReportController : ControllerBase
    {
        private readonly IOcurrenceAppService _ocurrenceAppService;
        private readonly IUserAppService _userAppService;
        private readonly IEmailSender _senderEmail;

        public ReportController(IOcurrenceAppService ocurrenceAppService, IUserAppService userAppService, IEmailSender senderEmail)
        {
            _ocurrenceAppService = ocurrenceAppService;
            _userAppService = userAppService;
            _senderEmail = senderEmail;
        }

        [HttpGet("{nonComplianceRegisterId:int}")]
        public async Task<IActionResult> GetReport(int nonComplianceRegisterId)
        {
            try
            {
                var responseService = await _ocurrenceAppService.CreateNonComplianceRegisterReport(nonComplianceRegisterId);

                if (!string.IsNullOrEmpty(responseService))
                    return Ok(responseService);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("email/{nonComplianceRegisterId:int}")]
        public async Task<IActionResult> SendReportOnEmail(int nonComplianceRegisterId)
        {
            var userAuthId = User.GetUserId();

            var user = await _userAppService.GetUserAuthById(userAuthId);

            if (user == null)
                BadRequest("Usuário não encontrado.");

            var report = await _ocurrenceAppService.CreateNonComplianceRegisterReport(nonComplianceRegisterId);

            if (string.IsNullOrEmpty(report))
                BadRequest("Relatório não gerado.");

            await _senderEmail.SendEmail(user.Email,
                                         "Relatório em anexo",
                                         "Relatorio do registro de não conformidade",
                                         GeneratePDF.FromHtml(report),
                                         "Relátorio",
                                         true);

            return Ok();
        }
    }
}

using _4lab.Administration.Application.Service;
using _4lab.Infrastructure.Smtp;
using _4lab.Occurrences.Application.Service;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Infrastructure.Render.PDF;
using Api.Rnc.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserPermissionType.QualityBiomedical))]
    public class ReportController : ControllerBase
    {
        private readonly IOccurrenceAppService _occurrenceAppService;
        private readonly IUserAppService _userAppService;
        private readonly IEmailSender _senderEmail;

        public ReportController(IOccurrenceAppService occurrenceAppService, IUserAppService userAppService, IEmailSender senderEmail)
        {
            _occurrenceAppService = occurrenceAppService;
            _userAppService = userAppService;
            _senderEmail = senderEmail;
        }

        [HttpGet("{occurrenceRegisterId:Guid}")]
        public async Task<IActionResult> GetReport(Guid occurrenceRegisterId)
        {
            try
            {
                var responseService = await _occurrenceAppService.CreateOccurrenceRegisterReport(occurrenceRegisterId);

                if (!string.IsNullOrEmpty(responseService))
                    return Ok(responseService);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("email/{occurrenceRegisterId:Guid}")]
        public async Task<IActionResult> SendReportOnEmail(Guid occurrenceRegisterId)
        {
            var userAuthId = User.GetUserId();

            var user = await _userAppService.GetUserAuthById(userAuthId);

            if (user == null)
                BadRequest("Usuário não encontrado.");

            var report = await _occurrenceAppService.CreateOccurrenceRegisterReport(occurrenceRegisterId);

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

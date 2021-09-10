using Api.Rnc.Extensions;
using Domain.Interfaces.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserPermissionType.AnalystBiomedical))]
    public class ReportController : ControllerBase
    {
        private readonly ICreateNonComplianceRegisterReportService _createNonConplianceRegisterReportService;
        private readonly ISendNonComplianceRegisterReportToEmailService _sendNonComplianceRegisterReportToEmailService;

        public ReportController(ICreateNonComplianceRegisterReportService createNonConplianceRegisterReportService,
                                ISendNonComplianceRegisterReportToEmailService sendNonComplianceRegisterReportToEmailService)
        {
            _createNonConplianceRegisterReportService = createNonConplianceRegisterReportService;
            _sendNonComplianceRegisterReportToEmailService = sendNonComplianceRegisterReportToEmailService;
        }
        [HttpGet("{nonComplianceRegisterId:int}")]
        public async Task<IActionResult> GetReport(int nonComplianceRegisterId)
        {
            var responseService = await _createNonConplianceRegisterReportService.Execute(nonComplianceRegisterId);
            if (responseService.Success)
                return Ok(responseService.Value);

            return BadRequest(responseService.Message);
        }
        [HttpGet("email/{nonComplianceRegisterId:int}")]
        public async Task<IActionResult> SendReportOnEmail(int nonComplianceRegisterId)
        {
            var userAuthId = User.GetUserId();
            var responseService = await _sendNonComplianceRegisterReportToEmailService.Execute(userAuthId, nonComplianceRegisterId);
            if (responseService.Success)
                return Ok();

            return BadRequest(responseService.Message);
        }
    }
}

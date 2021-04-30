using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SendNonComplianceRegisterReportToEmailService : AbstractService, ISendNonComplianceRegisterReportToEmailService
    {
        private readonly ICreateNonComplianceRegisterReportService _createNonConplianceRegisterReportService;
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IEmailSender _senderEmail;


        public SendNonComplianceRegisterReportToEmailService
            (ICreateNonComplianceRegisterReportService createNonConplianceRegisterReportService,
             IUserAuthRepository userAuthRepository,
             IEmailSender senderEmail)
        {
            _createNonConplianceRegisterReportService = createNonConplianceRegisterReportService;
            _userAuthRepository = userAuthRepository;
            _senderEmail = senderEmail;
        }
        public async Task<ResponseService> Execute(int userAuthId, int nonComplianceRegisterId)
        {
            var user = await _userAuthRepository.GetById(userAuthId);
            if (user == null)
                return GenerateErroServiceResponse("Usuário não encontrado.");

            var report = await _createNonConplianceRegisterReportService.Execute(nonComplianceRegisterId);

            if (!report.Success)
                return GenerateErroServiceResponse(report.Message);

            await _senderEmail.SendEmail(user.Email, report.Value, "Relatorio do registro de não conformidade", null, true);

            return GenerateSuccessServiceResponse();


        }
    }
}

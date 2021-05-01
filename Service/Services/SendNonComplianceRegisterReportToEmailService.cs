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
        private readonly IGeneratePDF _generatePDF;

        public SendNonComplianceRegisterReportToEmailService
            (ICreateNonComplianceRegisterReportService createNonConplianceRegisterReportService,
             IUserAuthRepository userAuthRepository,
             IEmailSender senderEmail,
             IGeneratePDF generatePDF)
        {
            _createNonConplianceRegisterReportService = createNonConplianceRegisterReportService;
            _userAuthRepository = userAuthRepository;
            _senderEmail = senderEmail;
            _generatePDF = generatePDF;
        }
        public async Task<ResponseService> Execute(int userAuthId, int nonComplianceRegisterId)
        {
            var user = await _userAuthRepository.GetById(userAuthId);
            if (user == null)
                return GenerateErroServiceResponse("Usuário não encontrado.");

            var report = await _createNonConplianceRegisterReportService.Execute(nonComplianceRegisterId);

            if (!report.Success)
                return GenerateErroServiceResponse(report.Message);

            await _senderEmail.SendEmail(user.Email,
                                         "Relatório em anexo",
                                         "Relatorio do registro de não conformidade",
                                         _generatePDF.FromHtml(report.Value),
                                         "Relátorio",
                                         true);

            return GenerateSuccessServiceResponse();


        }
    }
}

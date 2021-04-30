using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SeendChartToEmailService : AbstractService, ISendChartToEmailService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _senderEmail;
        private readonly ICreatePieChartWithNonComplianceRegisterService _createPieChartWithNonComplianceRegisterService;
        public SeendChartToEmailService(IEmailSender senderEmail,
                                        ICreatePieChartWithNonComplianceRegisterService createPieChartWithNonComplianceRegisterService,
                                        IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _senderEmail = senderEmail;
            _createPieChartWithNonComplianceRegisterService = createPieChartWithNonComplianceRegisterService;
        }

        public async Task<ResponseService> Execute(int userId, SetorType setor, int month)
        {
            var user = await _userRepository.GetByIdWithInclude(userId, nameof(User.UserAuth));

            if (user == null)
                return GenerateErroServiceResponse("Usuário não encontrado.");

            var chart = await _createPieChartWithNonComplianceRegisterService.Execute(setor, month);

            var template = "<p>O grafico está anexado.</p>";

            await _senderEmail.SendEmail(user.UserAuth.Email, template, "Grafico", chart.Value, true);

            return GenerateSuccessServiceResponse();

        }
    }
}

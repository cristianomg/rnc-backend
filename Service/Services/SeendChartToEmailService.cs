using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using Domain.ValueObjects;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SeendChartToEmailService : AbstractService, ISendChartToEmailService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEnviarEmail _enviarEmail;
        private readonly ICreatePieChartWithNonComplianceRegisterService _createPieChartWithNonComplianceRegisterService;
        public SeendChartToEmailService(IEnviarEmail enviarEmail,
                                        ICreatePieChartWithNonComplianceRegisterService createPieChartWithNonComplianceRegisterService,
                                        IUserRepository  userRepository)
        {
            _userRepository = userRepository;
            _enviarEmail = enviarEmail;
            _createPieChartWithNonComplianceRegisterService = createPieChartWithNonComplianceRegisterService;
        }

        public async Task<ResponseService> Execute(int userId, SetorType setor)
        {
            var user = await _userRepository.GetByIdWithInclude(userId, nameof(User.UserAuth));

            if (user == null)
                return GenerateErroServiceResponse("Usuário não encontrado.");

            var chart = await _createPieChartWithNonComplianceRegisterService.Execute(setor);

            var template = "<p>O grafico está anexado.</p>";

            await _enviarEmail.SendEmail(user.UserAuth.Email, template, "Grafico", chart.Value, true);

            return GenerateSuccessServiceResponse();

        }
    }
}

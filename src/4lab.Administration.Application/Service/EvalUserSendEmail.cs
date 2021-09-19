using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EvalUserSendEmail : AbstractService, IEvalUserSendEmail
    {
        public readonly IEmailSender _senderEmail;
        public EvalUserSendEmail(IEmailSender senderEmail)
        {
            _senderEmail = senderEmail;
        }
        public async Task<ResponseService> Approved(string email)
        {
            try
            {
                StringBuilder template = new StringBuilder();
                template.AppendLine("Olá, seu cadastro foi aprovado com sucesso.");
                template.AppendLine("Agora você poderá efetuar o login e se desfrutar com as funcionalidades do Rnc");
                template.AppendLine("");
                template.AppendLine("Atenciosamente, time do RNC");
                var subjectEmail = "Cadastro aprovado";

                await _senderEmail.SendEmail(email, template.ToString(), subjectEmail);
                return GenerateSuccessServiceResponse();
            }
            catch
            {
                return GenerateErroServiceResponse("Erro ao enviar email.");
            }
        }
        public async Task<ResponseService> Disapproved(string email)
        {
            try
            {
                StringBuilder template = new StringBuilder();
                template.AppendLine("Olá, seu cadastro infelizmente foi reprovado.");
                template.AppendLine("Você poderá realizar um novo cadastro, mas recomendamos que verifique com atenção os dados inseridos.");
                template.AppendLine("");
                template.AppendLine("Atenciosamente, time do RNC");

                var subjectEmail = "Cadastro reprovado";

                await _senderEmail.SendEmail(email, template.ToString(), subjectEmail);
                return GenerateSuccessServiceResponse();
            }
            catch
            {
                return GenerateErroServiceResponse("Erro ao enviar email.");
            }
        }
    }
}

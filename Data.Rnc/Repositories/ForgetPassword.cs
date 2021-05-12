using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using System.Text;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class ForgetPassword : IForgotPassword
    {
        public readonly IEmailSender _senderEmail;
        public ForgetPassword(IEmailSender senderEmail)
        {
            _senderEmail = senderEmail;
        }
        public async Task SendEmailToForgotpassword(string email, string name, string password)
        {
            StringBuilder template = new StringBuilder();
            template.AppendLine($"Olá <strong>{name}</strong>");
            template.AppendLine("<p>Recebemos uma solicitação para redefinir sua senha do RNC.</p>");
            template.AppendLine("</br>");
            template.AppendLine($"<p>Aqui está sua nova senha: <strong>{password}</strong></p>");
            template.AppendLine("</br>");
            template.AppendLine("<p>Recomendamos que você troque essa senha pois ela é provisória.</p>");
            template.AppendLine("</br>");
            template.AppendLine("<p>Atenciosamente, equipe RNC.</p>");

            var subjectEmail = "Envio de senha provisória";

            await _senderEmail.SendEmail(email, template.ToString(), subjectEmail, isHtml: true);
        }
    }
}

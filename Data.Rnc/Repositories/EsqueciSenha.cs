using Clinia.FluentMailer.Core;
using Clinia.FluentMailer.Smtp;
using Domain.Interfaces.Services;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class EsqueciSenha : IEsqueciSenha
    {
        public async Task SendEmail(string email)
        {
            var sender = new SmtpSender(() => new SmtpClient(host: "smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("paulobitt2000@gmail.com", "phmb0201")
            });

            StringBuilder template = new StringBuilder();
            template.AppendLine("Alá, no momento ainda estamos testando os códigos.");
            template.AppendLine("");
            template.AppendLine("- Time do RNC");

            Email.DefaultSender = sender;

            var sedEmail = await Email
                .From(emailAddress: "danilomichell14@gmail.com")
                .To(emailAddress: email.ToString())
                .Subject(subject: "Troca de senha")
                .Body(template.ToString())
                .SendAsync();
        }
    }
}

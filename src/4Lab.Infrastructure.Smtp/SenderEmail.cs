using _4Lab.Core.Configs;
using Clinia.FluentMailer.Core;
using Clinia.FluentMailer.Smtp;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace _4lab.Infrastructure.Smtp
{
    public class SenderEmail : IEmailSender
    {
        private readonly string _fromEmail;
        private readonly string _passwordEmail;

        public SenderEmail(IOptions<SendEmailConfig> emailDeEnvio)
        {
            _fromEmail = emailDeEnvio.Value.Email;
            _passwordEmail = emailDeEnvio.Value.Password;
        }

        public async Task SendEmail(string email, string template, string subjectEmail, byte[] anexo = null, string anexoName = null, bool isHtml = false)
        {
            var sender = new SmtpSender(() => new SmtpClient(host: "smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_fromEmail, _passwordEmail)
            });

            Email.DefaultSender = sender;

            var emailToSend = Email
                .From(emailAddress: _fromEmail)
                .To(emailAddress: email)
                .Subject(subject: subjectEmail)
                .Body(template, isHtml);

            if (anexo != null)
            {
                emailToSend.Attach(new Clinia.FluentMailer.Core.Models.Attachment()
                {
                    ContentType = "application/pdf",
                    Data = new MemoryStream(anexo),
                    Filename = anexoName ?? "Anexo",
                    IsInline = false
                });

            }

            await emailToSend.SendAsync();
        }
    }
}

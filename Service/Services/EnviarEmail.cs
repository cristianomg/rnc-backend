using Clinia.FluentMailer.Core;
using Clinia.FluentMailer.Smtp;
using Domain.Configs;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EnviarEmail : AbstractService, IEnviarEmail
    {
        private readonly string _fromEmail;
        private readonly string _passwordEmail;
        public EnviarEmail(IOptions<EnviarEmailConfig> emailDeEnvio)
        {
            _fromEmail = emailDeEnvio.Value.Email;
            _passwordEmail = emailDeEnvio.Value.Password;
        }

        public void SendEmailWithHtml(string email, string template, string subjectEmail)
        {
            MailAddress addressFrom = new MailAddress(_fromEmail, "RNC");
            MailAddress addressTo = new MailAddress(email);
            MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Body = template;
            message.IsBodyHtml = true;

            var client = new SmtpClient(host: "smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_fromEmail, _passwordEmail),
            };

            client.Send(message);
        }
        public async Task<ResponseService> SendEmail(string email,string template, string subjectEmail, byte[] anexo = null, bool isHtml = false)
        {
            var sender = new SmtpSender(() => new SmtpClient(host: "smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
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
                    Filename = "Grafico",
                    IsInline = false
                });

            }

            await emailToSend.SendAsync();
            return GenerateSuccessServiceResponse();
        }
    }
}

using Clinia.FluentMailer.Core;
using Clinia.FluentMailer.Smtp;
using Domain.Configs;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EnviarEmail : AbstractService, IEnviarEmail
    {
        private readonly string _fromEmail;
        public EnviarEmail(IOptions<EnviarEmailConfig> emailDeEnvio)
        {
            _fromEmail = emailDeEnvio.Value.Email;
        }
        public async Task<ResponseService> SendEmail(string email,StringBuilder template, string subjectEmail)
        {
            var sender = new SmtpSender(() => new SmtpClient(host: "smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromEmail, "phmb0201")
            });

            Email.DefaultSender = sender;

            var sedEmail = await Email
                .From(emailAddress: _fromEmail)
                .To(emailAddress: email)
                .Subject(subject: subjectEmail)
                .Body(template.ToString())
                .SendAsync();

            return GenerateSuccessServiceResponse();
        }
    }
}

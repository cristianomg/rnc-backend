using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using System.Net.Mail;
using FluentEmail.Smtp;
using System.Net;

namespace Api.Rnc.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Domain.Entities.Gmail model)
        {
            MailMessage mm = new MailMessage("paulobitt2000@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            var sender = new SmtpSender(() => new SmtpClient(host: "smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("paulobitt2000@gmail.com", "phmb0201")
            });
            return View();
        }
    }
}

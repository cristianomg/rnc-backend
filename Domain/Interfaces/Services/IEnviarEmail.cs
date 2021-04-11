using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISenderEmail : IService
    {
        Task<ResponseService> SendEmail(string email, string template, string subjectEmail, byte[] anexo = null, bool isHtml = false);
        void SendEmailWithHtml(string email, string template, string subjectEmail);
    }
}

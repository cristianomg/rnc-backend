using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEnviarEmail : IService
    {
        Task<ResponseService> SendEmail(string email, string template, string subjectEmail, bool isHtml = false);
        void SendEmailWithHtml(string email, string template, string subjectEmail);
    }
}

using System.Threading.Tasks;

namespace Domain.Interfaces.Util
{
    public interface IEmailSender
    {
        Task SendEmail(string email, string template, string subjectEmail, byte[] anexo = null, bool isHtml = false);
    }
}

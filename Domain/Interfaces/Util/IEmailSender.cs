using System.Threading.Tasks;

namespace Domain.Interfaces.Util
{
    public interface IEmailSender
    {
        Task SendEmail(string email, string template, string subjectEmail, byte[] anexo = null, string anexoName = null, bool isHtml = false);
    }
}

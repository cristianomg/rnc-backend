using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IForgotPassword
    {
        Task SendEmailToForgotpassword(string email, string name, string senha);
    }
}

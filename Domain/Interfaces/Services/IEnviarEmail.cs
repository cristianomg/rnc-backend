using Domain.Models.Helps;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEnviarEmail : IService
    {
        Task<ResponseService> SendEmail(string email, StringBuilder template, string subjectEmail);
    }
}

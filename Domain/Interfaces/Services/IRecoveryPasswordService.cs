using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IRecoveryPasswordService
    {
        Task<ResponseService> Execute(string email);
    }
}

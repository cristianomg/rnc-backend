using Domain.Models.Helps;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISendChartToEmailService : IService
    {
        Task<ResponseService> Execute(int userId, SetorType setor, int month);
    }
}

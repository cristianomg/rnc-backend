using Domain.Models.Helps;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISendChartToEmailService : IService
    {
        Task<ResponseService<string>> Execute(SetorType setor);
    }
}

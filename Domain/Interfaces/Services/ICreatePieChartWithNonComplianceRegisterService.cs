using Domain.Models.Helps;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreatePieChartWithNonComplianceRegisterService : IService
    {
        Task<ResponseService<byte[]>> Execute(SetorType setor);
    }
}

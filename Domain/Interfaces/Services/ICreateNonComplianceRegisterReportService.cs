using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateNonComplianceRegisterReportService : IService
    {
        Task<ResponseService<string>> Execute(int nonComplianceRegisterId);
    }
}

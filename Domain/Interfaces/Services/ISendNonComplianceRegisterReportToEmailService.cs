using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISendNonComplianceRegisterReportToEmailService : IService
    {
        Task<ResponseService> Execute(int userAuthId, int nonComplianceRegisterId);
    }
}

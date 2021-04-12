using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface INonComplianceRepository : IBaseRepository<NonCompliance>
    {
        IQueryable<NonCompliance> GetByTypeNonCompliance(int typeNonComplianceId);
    }
}

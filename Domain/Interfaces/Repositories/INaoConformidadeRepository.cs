using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces.Repositories
{
    public interface INonComplianceRepository : IBaseRepository<NonCompliance, int>
    {
        IQueryable<NonCompliance> GetByTypeNonCompliance(int typeNonComplianceId);
    }
}

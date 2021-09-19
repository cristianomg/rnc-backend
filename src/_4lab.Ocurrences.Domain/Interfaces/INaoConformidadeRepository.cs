using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using System.Linq;

namespace _4lab.Ocurrences.Domain.Interfaces
{
    public interface INonComplianceRepository : IBaseRepository<NonCompliance, int>
    {
        IQueryable<NonCompliance> GetByTypeNonCompliance(int typeNonComplianceId);
    }
}

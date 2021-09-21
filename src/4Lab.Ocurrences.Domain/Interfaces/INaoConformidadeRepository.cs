using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Linq;

namespace _4lab.Ocurrences.Domain.Interfaces
{
    public interface INonComplianceRepository : IBaseRepository<NonCompliance, Guid>
    {
        IQueryable<NonCompliance> GetByTypeNonCompliance(NonComplianceType typeNonComplianceId);
    }
}

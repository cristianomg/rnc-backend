using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Domain.Interfaces
{
    public interface IOccurrenceRepository : IBaseRepository<Occurrence, Guid>
    {
        Task<IQueryable<Occurrence>> GetByOccurrenceType(OccurrenceType ocurrencyType);
    }
}

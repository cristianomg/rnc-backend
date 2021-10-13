using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;

namespace _4Lab.Occurrences.Domain.Interfaces
{
    public interface IOccurrenceRegisterTypeRepository : IBaseRepository<TypeOccurrence, OccurrenceType>
    {
    }
}

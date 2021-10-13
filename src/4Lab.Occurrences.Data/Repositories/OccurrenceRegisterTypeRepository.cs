using _4lab.Occurrences.Data;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Occurrences.Domain.Interfaces;

namespace _4Lab.Occurrences.Data.Repositories
{
    public class OccurrenceRegisterTypeRepository : BaseRepository<TypeOccurrence, OccurrenceType>, IOccurrenceRegisterTypeRepository
    {
        public OccurrenceRegisterTypeRepository(OccurrencesContext context): base(context)
        {

        }
    }
}

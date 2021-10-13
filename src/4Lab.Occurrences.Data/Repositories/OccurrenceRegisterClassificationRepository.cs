using _4lab.Occurrences.Data;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Occurrences.Domain.Interfaces;

namespace _4Lab.Occurrences.Data.Repositories
{
    public class OccurrenceRegisterClassificationRepository : BaseRepository<OccurrenceClassification, OccurrenceClassificationType>, IOccurrenceRegisterClassificationRepository
    {
        public OccurrenceRegisterClassificationRepository(OccurrencesContext context ) : base(context)
        {

        }
    }
}

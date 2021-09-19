using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Domain.Interfaces
{
    public interface IOccurrenceClassificationRepository : IBaseRepository<OccurrenceClassification, OccurrenceClassificationType>
    {
        Task<IQueryable<OccurrenceClassification>> GetAllClassification();
    }
}

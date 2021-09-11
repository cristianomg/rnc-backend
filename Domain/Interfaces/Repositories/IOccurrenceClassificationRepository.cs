using Domain.Entities;
using Domain.ValueObjects;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IOccurrenceClassificationRepository : IBaseRepository<OccurrenceClassification, OccurrenceClassificationType>
    {
        Task<IQueryable<OccurrenceClassification>> GetAllClassification();
    }
}

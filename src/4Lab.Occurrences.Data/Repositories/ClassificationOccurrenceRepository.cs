using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Data.Repositories
{
    public class OccurrenceClassificationRepository : BaseRepository<OccurrenceClassification, OccurrenceClassificationType>, IOccurrenceClassificationRepository
    {
        private readonly DbSet<OccurrenceClassification> _dbSet;
        public OccurrenceClassificationRepository(OccurrencesContext context) : base(context)
        {
            _dbSet = context.Set<OccurrenceClassification>();
        }
        public async Task<IQueryable<OccurrenceClassification>> GetAllClassification()
        {
            var occurrenceClassification = _dbSet.AsQueryable().OrderBy(x => x.Id);
            return await Task.FromResult(occurrenceClassification);
        }
    }
}

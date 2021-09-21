using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Data.Repositories
{
    public class OccurrenceClassificationRepository : BaseRepository<OccurrenceClassification, OccurrenceClassificationType>, IOccurrenceClassificationRepository
    {
        private readonly DbSet<OccurrenceClassification> _dbSet;
        public OccurrenceClassificationRepository(OcurrencesContext context) : base(context)
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

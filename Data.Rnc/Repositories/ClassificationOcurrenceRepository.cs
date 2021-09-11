using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class OccurrenceClassificationRepository : BaseRepository<OccurrenceClassification, OccurrenceClassificationType>, IOccurrenceClassificationRepository
    {
        private readonly DbSet<OccurrenceClassification> _dbSet;
        public OccurrenceClassificationRepository(RncContext context) : base(context)
        {
            _dbSet = context.Set<OccurrenceClassification>();
        }
        public async Task<IQueryable<OccurrenceClassification>> GetAllClassification()
        {
            var occurrenceClassification = _dbSet.AsQueryable().OrderBy(x=>x.Id);
            return await Task.FromResult(occurrenceClassification);
        }
    }
}

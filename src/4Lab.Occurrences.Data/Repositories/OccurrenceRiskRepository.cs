using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Data.Repositories
{
    public class OccurrenceRiskRepository : BaseRepository<OccurrenceRisk, OccurrenceRiskType>, IOccurrenceRiskRepository
    {
        private readonly DbSet<OccurrenceRisk> _dbSet;
        public OccurrenceRiskRepository(OccurrencesContext context) : base(context)
        {
            _dbSet = context.Set<OccurrenceRisk>();
        }
        public async Task<IQueryable<OccurrenceRisk>> GetAllRisks()
        {
            var occurrenceClassification = _dbSet.AsQueryable().OrderBy(x => x.Id);
            return await Task.FromResult(occurrenceClassification);
        }
    }
}

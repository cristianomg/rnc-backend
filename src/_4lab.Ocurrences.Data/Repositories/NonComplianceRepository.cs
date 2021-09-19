using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _4lab.Ocurrences.Data.Repositories
{
    public class NonComplianceRepository : BaseRepository<NonCompliance, int>, INonComplianceRepository
    {
        private readonly DbSet<NonCompliance> _dbSet;
        public NonComplianceRepository(OcurrencesContext context) : base(context)
        {
            _dbSet = context.Set<NonCompliance>();
        }
        public IQueryable<NonCompliance> GetByTypeNonCompliance(int typeNonComplianceId)
        {
            return _dbSet.AsNoTracking().Include(n => n.TypeNonCompliance).Where(t => t.TypeNonComplianceId == typeNonComplianceId && t.Active)
                .OrderBy(t => t.Id).AsQueryable();
        }
    }
}

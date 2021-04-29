using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class NonComplianceRepository : BaseRepository<NonCompliance>, INonComplianceRepository
    {
        private readonly DbSet<NonCompliance> _dbSet;
        public NonComplianceRepository(RncContext context) : base(context)
        {
            _dbSet = context.Set<NonCompliance>();
        }
        public IQueryable<NonCompliance> GetByTypeNonCompliance(int typeNonComplianceId)
        {
            return _dbSet.AsNoTracking().Include(n => n.TypeNonCompliance).Where(t=>t.TypeNonComplianceId == typeNonComplianceId && t.Active)
                .OrderBy(t => t.Id).AsQueryable();
        }
    }
}

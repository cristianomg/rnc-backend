using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _4lab.Ocurrences.Data.Repositories
{
    public class NonComplianceRepository : BaseRepository<NonCompliance, Guid>, INonComplianceRepository
    {
        private readonly DbSet<NonCompliance> _dbSet;
        public NonComplianceRepository(OcurrencesContext context) : base(context)
        {
            _dbSet = context.NonCompliance;
        }
        public IQueryable<NonCompliance> GetByTypeNonCompliance(NonComplianceType typeNonComplianceId)
        {
            return _dbSet.AsNoTracking().Include(n => n.TypeNonCompliance)
                .Where(t => t.TypeNonComplianceId == typeNonComplianceId && t.Active)
                .OrderBy(t => t.Id).AsQueryable();
        }
    }
}

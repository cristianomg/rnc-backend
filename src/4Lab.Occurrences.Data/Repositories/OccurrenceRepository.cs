using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Data.Repositories
{
    public class OccurrenceRepository : BaseRepository<Occurrence, Guid>, IOccurrenceRepository
    {
        private readonly DbSet<Occurrence> _dbSet;
        public OccurrenceRepository(OccurrencesContext context) : base(context)
        {
            _dbSet = context.Occurrences;
        }
        public async Task<IQueryable<Occurrence>> GetByOccurrenceType(OccurrenceType occurrenceType)
        {
            return await Task.FromResult(_dbSet
                                            .AsNoTracking()
                                            .Where(t => t.OccurrenceTypeId == occurrenceType &&
                                                   t.Active)
                                            .OrderBy(t => t.Id)
                                            .AsQueryable()
                                        );

                        
        }
    }
}

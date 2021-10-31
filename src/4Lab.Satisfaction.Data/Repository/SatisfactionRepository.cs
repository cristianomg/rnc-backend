using _4Lab.Core.Data;
using _4Lab.Satisfaction.Domain.Entities;
using _4Lab.Satisfaction.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Data.Repository
{
    public class SatisfactionRepository : BaseRepository<SatisfactionSurvey, Guid>, ISatisfactionRepository
    {
        private readonly DbSet<SatisfactionSurvey> _dbSet;
        public SatisfactionRepository(SatisfactionContext context) : base(context)
        {
            _dbSet = context.Set<SatisfactionSurvey>();
        }
        public Task<SatisfactionSurvey> GetSatisfactionSurvey(Guid guid)
        {
            var result = _dbSet.Where(x => x.Id == guid).FirstOrDefaultAsync();
            return result;
        }
    }
}

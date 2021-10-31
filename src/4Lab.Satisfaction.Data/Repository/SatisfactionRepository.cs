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
        public Task<SatisfactionSurvey> GetSatisfactionSurveyById(Guid guid)
        {
            var result = _dbSet.Where(x => x.Id == guid)
                                .Include(x => x.Reception)
                                .Include(x => x.TecnicalArea)
                                .Include(x => x.Sanitation)
                                .Include(x => x.DeliveryResults)
                                .Include(x => x.OverallImpression)
                                .Include(x => x.HowSatisfied)
                                .Include(x => x.OurDifferential)
                                .Include(x => x.WhySearch)
                                .Include(x => x.PersonalInformations)
                                .FirstOrDefaultAsync();
            return result;
        }
        public Task<IQueryable<SatisfactionSurvey>> GetSatisfactionSurveyAll()
        {
            var result = _dbSet.Include(x => x.Reception)
                                .Include(x => x.TecnicalArea)
                                .Include(x => x.Sanitation)
                                .Include(x => x.DeliveryResults)
                                .Include(x => x.OverallImpression)
                                .Include(x => x.HowSatisfied)
                                .Include(x => x.OurDifferential)
                                .Include(x => x.WhySearch)
                                .Include(x => x.PersonalInformations)
                                .AsQueryable();
            return Task.FromResult(result);
        }
    }
}

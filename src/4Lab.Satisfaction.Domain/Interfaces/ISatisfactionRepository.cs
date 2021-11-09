using _4Lab.Core.Data;
using _4Lab.Satisfaction.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Domain.Interfaces
{
    public interface ISatisfactionRepository : IBaseRepository<SatisfactionSurvey, Guid>
    {
        Task<IQueryable<SatisfactionSurvey>> GetSatisfactionSurveyAll();
        Task<SatisfactionSurvey> GetSatisfactionSurveyById(Guid guid);
    }
}

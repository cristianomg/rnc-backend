using _4Lab.Core.Data;
using _4Lab.Satisfaction.Domain.Entities;
using System;

namespace _4Lab.Satisfaction.Domain.Interfaces
{
    public interface ISatisfactionRepository : IBaseRepository<SatisfactionSurvey, Guid>
    {
    }
}

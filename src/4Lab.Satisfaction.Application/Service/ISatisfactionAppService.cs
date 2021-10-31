using _4Lab.Satisfaction.Application.DTOs;
using _4Lab.Satisfaction.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Application.Service
{
    public interface ISatisfactionAppService
    {
        Task<IQueryable<DtoSatisfactionSurveyResponse>> GetSatisfactionSurveyAll();
        Task<DtoSatisfactionSurveyResponse> GetSatisfactionSurveyById(Guid id);
        Task<DtoSatisfactionSurveyInput> RegisterSatisfactionSurvey(SatisfactionSurvey satisfactionSurvey);
    }
}

using _4Lab.Satisfaction.Application.DTOs;
using _4Lab.Satisfaction.Domain.Entities;
using _4Lab.Satisfaction.Domain.Interfaces;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Application.Service
{
    public class SatisfactionAppService : ISatisfactionAppService
    {
        private readonly IMapper _mapper;
        private readonly ISatisfactionRepository _satisfactionRepository;
        public SatisfactionAppService(IMapper mapper, ISatisfactionRepository satisfactionRepository)
        {
            _satisfactionRepository = satisfactionRepository;
            _mapper = mapper;
        }

        public async Task RegisterSatisfactionSurvey(DtoSatisfactionSurveyInput satisfactionSurvey)
        {
            var entity = _mapper.Map<SatisfactionSurvey>(satisfactionSurvey);
            await _satisfactionRepository.Insert(entity);
        }

        public async Task<DtoSatisfactionSurveyResponse> GetSatisfactionSurveyById(Guid id)
        {
            var result = await _satisfactionRepository.GetSatisfactionSurveyById(id);
            return _mapper.Map<DtoSatisfactionSurveyResponse>(result);
        }
        public async Task<IQueryable<DtoSatisfactionSurveyResponse>> GetSatisfactionSurveyAll()
        {
            var result = await _satisfactionRepository.GetSatisfactionSurveyAll();
            return _mapper.Map<IQueryable<DtoSatisfactionSurveyResponse>>(result);
        }
    }
}

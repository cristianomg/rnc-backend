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
        //private readonly ISatisfactionRepository _satisfactionRepository;
        public SatisfactionAppService(IMapper mapper)
        {
            //_satisfactionRepository = satisfactionRepository;
            _mapper = mapper;
        }

        public Task<IQueryable<DtoSatisfactionSurveyResponse>> GetSatisfactionSurveyAll()
        {
            throw new NotImplementedException();
        }

        public Task<DtoSatisfactionSurveyResponse> GetSatisfactionSurveyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DtoSatisfactionSurveyInput> RegisterSatisfactionSurvey(SatisfactionSurvey satisfactionSurvey)
        {
            throw new NotImplementedException();
        }
        //public async Task<DtoSatisfactionSurveyInput> RegisterSatisfactionSurvey(SatisfactionSurvey satisfactionSurvey)
        //{
        //    var result = await _satisfactionRepository.Insert(satisfactionSurvey);
        //    return _mapper.Map<DtoSatisfactionSurveyInput>(result);
        //}

        //public async Task<DtoSatisfactionSurveyResponse> GetSatisfactionSurveyById(Guid id)
        //{ 
        //    var result = await _satisfactionRepository.GetSatisfactionSurveyById(id);
        //    return _mapper.Map<DtoSatisfactionSurveyResponse>(result);
        //}
        //public async Task<IQueryable<DtoSatisfactionSurveyResponse>> GetSatisfactionSurveyAll()
        //{
        //    var result = await _satisfactionRepository.GetSatisfactionSurveyAll();
        //    return _mapper.Map<IQueryable<DtoSatisfactionSurveyResponse>>(result);
        //}
    }
}

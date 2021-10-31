using _4Lab.Satisfaction.Domain.Entities;
using _4Lab.Satisfaction.Domain.Interfaces;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Application.Service
{
    public class SatisfactionAppService : ISatisfactionAppService
    {
        private readonly ISatisfactionRepository _satisfactionRepository;
        public SatisfactionAppService(ISatisfactionRepository satisfactionRepository)
        {
            _satisfactionRepository = satisfactionRepository;
        }
        public async Task<int> RegisterSatisfactionSurvey(SatisfactionSurvey satisfactionSurvey)
        {
            var result = await _satisfactionRepository.Insert(satisfactionSurvey);
            return 0;
        }

        public async Task<int> GetSatisfactionSurvey()
        {
            return 0;
        }
    }
}

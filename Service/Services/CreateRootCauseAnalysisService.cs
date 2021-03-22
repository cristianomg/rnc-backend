using System.Threading.Tasks;
using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;

namespace Service.Services
{
    public class CreateRootCauseAnalysisService : AbstractService, ICreateRootCauseAnalysisService
    {
        private readonly IRootCauseAnalysisRepository _analyzeRootCauseRepository;
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        public CreateRootCauseAnalysisService(IRootCauseAnalysisRepository analyzeRootCauseRepository,
                                      INonComplianceRegisterRepository nonComplianceRegisterRepository)
        {
            _analyzeRootCauseRepository = analyzeRootCauseRepository;
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
        }
        public async Task<ResponseService<RootCauseAnalysis>> Execute(int userId, DtoRootCauseAnalysisInput analyzeRootCause)
        {
            var nonComplianceRegister = await
                _nonComplianceRegisterRepository.GetById(analyzeRootCause.NonComplianceRegisterId);

            if (nonComplianceRegister == null)
                return GenerateErroServiceResponse<RootCauseAnalysis>("Registro de não conformidade não encontrado.");

            if (nonComplianceRegister.RootCauseAnalysis != null)
                return GenerateErroServiceResponse<RootCauseAnalysis>
                       ("O registro de não conformidade já foi analisado.");

            var newAnalyzeRootCause = await _analyzeRootCauseRepository.Insert(new RootCauseAnalysis
            {
                NonComplianceRegisterId = analyzeRootCause.NonComplianceRegisterId,
                UserId = userId,
                Analyze = analyzeRootCause.Analyze
            });

            await _analyzeRootCauseRepository.SaveChanges();

            return GenerateSuccessServiceResponse(newAnalyzeRootCause);
        }
    }
}

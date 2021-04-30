using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CreateNonComplianceRegisterReportService : AbstractService, ICreateNonComplianceRegisterReportService
    {
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IRazorViewToStringRenderer _razorRender;
        public CreateNonComplianceRegisterReportService(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                                   IRazorViewToStringRenderer razorRender,
                                   IUserAuthRepository userAuthRepository)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _razorRender = razorRender;
        }
        public async Task<ResponseService<string>> Execute(int nonComplianceRegisterId)
        {
            var nonComplianceRegister = await _nonComplianceRegisterRepository.GetByIdForReport(nonComplianceRegisterId);

            if (nonComplianceRegister == null)
                return GenerateErroServiceResponse<string>("Registro de não conformidade não encontrado.");

            if (!nonComplianceRegister.HasRootCauseAnalysis())
                return GenerateErroServiceResponse<string>("Resgistro ainda não possui analise de causa raiz.");

            var html = await _razorRender.RenderViewToStringAsync("NonComplianceRegisterReport", nonComplianceRegister);

            return GenerateSuccessServiceResponse(html);
        }
    }
}

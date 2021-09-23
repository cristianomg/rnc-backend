using _4lab.Occurrences.Application.DTOs;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Occurrences.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Application.Service
{
    public interface IOccurrenceAppService
    {
        Task<bool> CreateActionPlain(DtoCreateActionPlainInput dto);
        Task<bool> CreateOccurrenceRegister(DtoOccurrenceRegister nonCompliance);
        Task<bool> CreateRootCauseAnalysis(DtoRootCauseAnalysisInput analyzeRootCause);
        Task<bool> CreateRiskAnalysis(DtoRiskAnalysisInput riskAnalysis);
        Task<DtoOccurrenceRegisterResponse> GetOccurrenceRegisterById(Guid id);
        Task<byte[]> CreatePieChartWithOccurrenceRegister(SetorType setor, int month);
        Task<string> CreateOccurrenceRegisterReport(Guid occurrenceRegisterId);
    }
}

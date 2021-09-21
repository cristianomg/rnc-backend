using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Application.Service
{
    public interface IOcurrenceAppService
    {
        Task<bool> CreateActionPlain(DtoCreateActionPlainInput dto);
        Task<bool> CreateNonComplianceRegister(DtoNonComplianceRegister nonCompliance);
        Task<RootCauseAnalysis> CreateRootCauseAnalysis(DtoRootCauseAnalysisInput analyzeRootCause);
        Task<DtoNonComplianceRegisterResponse> GetNonComplieanceRegisterById(Guid id);
        Task<byte[]> CreatePieChartWithNonComplianceRegister(SetorType setor, int month);
        Task<string> CreateNonComplianceRegisterReport(Guid nonComplianceRegisterId);
    }
}

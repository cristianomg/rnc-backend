using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Application.Service
{
    public interface IOccurrenceAppService
    {
        Task<bool> CreateActionPlain(DtoCreateActionPlainInput dto);
        Task<bool> CreateOccurrenceRegister(DtoOccurrenceRegister nonCompliance);
        Task<RootCauseAnalysis> CreateRootCauseAnalysis(DtoRootCauseAnalysisInput analyzeRootCause);
        Task<DtoOccurrenceRegisterResponse> GetOccurrenceRegisterById(Guid id);
        Task<byte[]> CreatePieChartWithOccurrenceRegister(SetorType setor, int month);
        Task<string> CreateOccurrenceRegisterReport(Guid occurrenceRegisterId);
    }
}

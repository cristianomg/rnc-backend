using _4lab.Ocurrences.Application.DTOs;
using Domain.Entities;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateRootCauseAnalysisService : IService
    {
        Task<ResponseService<RootCauseAnalysis>> Execute(DtoRootCauseAnalysisInput rootCauseAnalysis);
    }
}

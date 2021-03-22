using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateRootCauseAnalysisService : IService
    {
        Task<ResponseService<RootCauseAnalysis>> Execute(int userId, DtoRootCauseAnalysisInput rootCauseAnalysis);
    }
}

using _4Lab.Orchestrator.DTOs.Response;
using System;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Interfaces
{
    public interface IGetOccurrenceRegisterByIdFacade
    {
        Task<DtoOccurrenceRegisterFacadeResponse> Execute(Guid id);
    }
}

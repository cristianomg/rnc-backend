using _4Lab.Orchestrator.DTOs.Response;
using System;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Interfaces
{
    public interface IGetOcurrenceRegisterByIdFacade
    {
        Task<DtoOcurrenceRegisterFacadeResponse> Execute(Guid id);
    }
}

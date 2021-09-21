using _4Lab.Orchestrator.DTOs.Inputs;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Interfaces
{
    public interface ICreateOccurrenceRegisterFacade 
    {
        Task<bool> Execute(DtoOccurrenceRegisteFacaderInput input);
    }
}

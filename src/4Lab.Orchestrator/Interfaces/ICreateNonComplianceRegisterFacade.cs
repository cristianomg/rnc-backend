using _4Lab.Orchestrator.DTOs.Inputs;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Interfaces
{
    public interface ICreateNonComplianceRegisterFacade 
    {
        Task<bool> Execute(DtoOcurrenceRegisteFacaderInput input);
    }
}

using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Orchestrator.DTOs.Inputs;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Interfaces
{
    public interface INonComplianceRegisterFacade 
    {
        Task<bool> Register(DtoNonComplianceRegisterInput input);
    }
}

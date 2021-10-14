using _4Lab.Occurrences.Application.DTOs;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Interfaces
{
    public interface ICreateVerificationOfEffectivenessFacade 
    {
        Task<bool> Execute(DtoVerificationOfEffectivenessInput analysis);
    }
}

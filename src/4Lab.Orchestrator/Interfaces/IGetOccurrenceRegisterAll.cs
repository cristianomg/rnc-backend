using _4lab.Occurrences.Application.DTOs;
using _4Lab.Orchestrator.DTOs.Response;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Interfaces
{
    public interface IGetOccurrenceRegisterAll
    {
        Task<IQueryable<DtoOccurrenceRegisterFacadeResponse>> Execute(IQueryable<DtoOccurrenceRegisterResponse> dtoOccurrences);
    }
}

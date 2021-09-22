using _4lab.Occurrences.Application.DTOs;
using _4Lab.Core.DomainObjects.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Application.Service
{
    public interface ISetorAppService
    {
        Task<DtoSetor> GetById(SetorType id);
        Task Update(DtoSetor setor);
        Task<IQueryable<DtoSetor>> GetAllSetor();
    }
}

using _4lab.Ocurrences.Application.DTOs;
using _4Lab.Core.DomainObjects.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Application.Service
{
    public interface ISetorAppService
    {
        Task<DtoSetor> GetById(SetorType id);
        Task Update(DtoSetor setor);
        Task<IQueryable<DtoSetor>> GetAllSetor();
    }
}

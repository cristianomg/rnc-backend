using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Domain.Interfaces
{
    public interface ISetorRepository : IBaseRepository<Setor, SetorType>
    {
        Task<IQueryable<Setor>> GetAllSetor();
    }
}

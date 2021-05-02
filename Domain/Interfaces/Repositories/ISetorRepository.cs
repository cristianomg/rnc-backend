using Domain.Entities;
using Domain.ValueObjects;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ISetorRepository : IBaseRepository<Setor, SetorType>
    {
        Task<IQueryable<Setor>> GetAllSetor();
    }
}

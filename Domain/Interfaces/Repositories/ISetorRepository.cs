using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ISetorRepository : IBaseRepository<Setor>
    {
        Task<IQueryable<Setor>> GetAllSetor();
    }
}

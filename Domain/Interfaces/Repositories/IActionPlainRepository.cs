using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IActionPlainRepository : IBaseRepository<ActionPlain, int>
    {
        public Task<ActionPlain> GetByIdWithIncludes(int id);
    }
}

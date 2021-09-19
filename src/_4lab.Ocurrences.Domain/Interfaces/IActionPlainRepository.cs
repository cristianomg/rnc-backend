using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Domain.Interfaces
{
    public interface IActionPlainRepository : IBaseRepository<ActionPlain, int>
    {
        public Task<ActionPlain> GetByIdWithIncludes(int id);
    }
}

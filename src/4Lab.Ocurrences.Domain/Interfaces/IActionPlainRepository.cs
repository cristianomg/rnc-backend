using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using System;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Domain.Interfaces
{
    public interface IActionPlainRepository : IBaseRepository<ActionPlain, Guid>
    {
        public Task<ActionPlain> GetByIdWithIncludes(Guid id);
    }
}

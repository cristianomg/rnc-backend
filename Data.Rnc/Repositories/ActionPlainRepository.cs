using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class ActionPlainRepository : BaseRepository<ActionPlain, int>, IActionPlainRepository
    {
        private readonly RncContext _context;
        public ActionPlainRepository(RncContext context) : base(context)
        {
            _context = context;
        }

        public Task<ActionPlain> GetByIdWithIncludes(int id)
        {
            return _context.ActionPlains
                .AsQueryable()
                .Include(x => x.Questions)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

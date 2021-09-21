using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Data.Repositories
{
    public class ActionPlainRepository : BaseRepository<ActionPlain, Guid>, IActionPlainRepository
    {
        private readonly OcurrencesContext _context;
        public ActionPlainRepository(OcurrencesContext context) : base(context)
        {
            _context = context;
        }

        public Task<ActionPlain> GetByIdWithIncludes(Guid id)
        {
            return _context.ActionPlains
                .AsQueryable()
                .Include(x => x.Questions)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

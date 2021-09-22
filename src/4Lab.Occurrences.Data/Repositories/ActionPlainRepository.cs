using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Data.Repositories
{
    public class ActionPlainRepository : BaseRepository<ActionPlain, Guid>, IActionPlainRepository
    {
        private readonly OccurrencesContext _context;
        public ActionPlainRepository(OccurrencesContext context) : base(context)
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

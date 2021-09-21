using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Data.Repositories
{
    public class SetorRepository : BaseRepository<Setor, SetorType>, ISetorRepository
    {
        private readonly DbSet<Setor> _dbSet;

        public SetorRepository(OccurrencesContext context) : base(context)
        {
            _dbSet = context.Set<Setor>();
        }

        public async Task<IQueryable<Setor>> GetAllSetor()
        {
            var setor = _dbSet.AsQueryable();
            return await Task.FromResult(setor);
        }
    }
}

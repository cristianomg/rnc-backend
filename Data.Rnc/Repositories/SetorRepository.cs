using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class SetorRepository : BaseRepository<Setor, SetorType>, ISetorRepository
    {
        private readonly DbSet<Setor> _dbSet;
        public SetorRepository(RncContext context) : base(context)
        {
            _dbSet = context.Set<Setor>();
        }
        public async Task<IQueryable<Setor>> GetAllSetor()
        {
            var setor = _dbSet.Include(x => x.Users).AsQueryable();
            return await Task.FromResult(setor);
        }
    }
}

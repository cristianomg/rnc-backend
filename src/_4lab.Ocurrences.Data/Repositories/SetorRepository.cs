using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Data.Repositories
{
    public class SetorRepository : BaseRepository<Setor, SetorType>, ISetorRepository
    {
        private readonly DbSet<Setor> _dbSet;
        public SetorRepository(OcurrencesContext context) : base(context)
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

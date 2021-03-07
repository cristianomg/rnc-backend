using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class NaoConformidadeRepository : BaseRepository<NaoConformidade>, INaoConformidadeRepository
    {
        private readonly DbSet<NaoConformidade> _dbSet;
        public NaoConformidadeRepository(RncContext context) : base(context)
        {
            _dbSet = context.Set<NaoConformidade>();
        }
        public async Task<IEnumerable<NaoConformidade>> GetByTipoNaoConformidade(int tipoNaoConformidadeId)
        {
            return await _dbSet.AsNoTracking().Include(n => n.TipoNaoConformidade)
                .OrderBy(t => t.Descricao).ToListAsync();
        }
    }
}

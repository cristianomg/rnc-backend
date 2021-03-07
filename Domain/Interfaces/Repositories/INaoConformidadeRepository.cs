using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface INaoConformidadeRepository : IBaseRepository<NaoConformidade>
    {
        Task<IEnumerable<NaoConformidade>> GetByTipoNaoConformidade(int tipoNaoConformidadeId);
    }
}

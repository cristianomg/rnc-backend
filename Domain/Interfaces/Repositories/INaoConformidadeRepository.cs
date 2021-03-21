using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface INaoConformidadeRepository : IBaseRepository<NaoConformidade>
    {
        IQueryable<NaoConformidade> GetByTipoNaoConformidade(int tipoNaoConformidadeId);
    }
}

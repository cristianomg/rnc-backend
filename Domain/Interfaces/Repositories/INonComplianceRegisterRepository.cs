using Domain.Entities;
using Domain.ValueObjects;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface INonComplianceRegisterRepository : IBaseRepository<NonComplianceRegister>
    {
        Task<NonComplianceRegister> GetByIdWithInclude(int id);
        Task<IQueryable<NonComplianceRegister>> GetBySetor(SetorType setor);
    }
}

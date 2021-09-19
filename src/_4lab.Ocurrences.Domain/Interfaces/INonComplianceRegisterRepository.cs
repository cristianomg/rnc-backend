using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Domain.Interfaces
{
    public interface INonComplianceRegisterRepository : IBaseRepository<NonComplianceRegister, int>
    {
        Task<NonComplianceRegister> GetByIdWithInclude(int id);
        Task<IQueryable<NonComplianceRegister>> GetBySetor(SetorType setor, DateTime initialDate, DateTime finalDate);
        Task<IQueryable<NonComplianceRegisterGroup>> GetGroupBySetor(SetorType setor, int month);
        Task<NonComplianceRegister> GetByIdForReport(int id);
    }
}

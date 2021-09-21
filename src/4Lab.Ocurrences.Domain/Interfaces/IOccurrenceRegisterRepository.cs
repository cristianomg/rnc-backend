using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Domain.Interfaces
{
    public interface IOccurrenceRegisterRepository : IBaseRepository<OccurrenceRegister, Guid>
    {
        Task<OccurrenceRegister> GetByIdWithInclude(Guid id);
        Task<IQueryable<OccurrenceRegister>> GetBySetor(SetorType setor, DateTime initialDate, DateTime finalDate);
        Task<IQueryable<OccurrenceGroup>> GetGroupBySetor(SetorType setor, int month);
        Task<OccurrenceRegister> GetByIdForReport(Guid id);
    }
}

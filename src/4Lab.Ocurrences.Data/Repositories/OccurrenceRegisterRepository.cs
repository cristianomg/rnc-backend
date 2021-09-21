using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Occurrences.Data.Repositories
{
    public class OccurrenceRegisterRepository : BaseRepository<OccurrenceRegister, Guid>, IOccurrenceRegisterRepository
    {
        private readonly OccurrencesContext _context;
        public OccurrenceRegisterRepository(OccurrencesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OccurrenceRegister> GetByIdWithInclude(Guid id)
        {
            var nonComplianceRegister = await _context.OccurrenceRegisters.AsNoTracking()
                 .Include(x => x.Setor)
                 .Include(x => x.RootCauseAnalysis)
                 .Include(x => x.Occurrences)
                 .FirstOrDefaultAsync(x => x.Id == id);

            return nonComplianceRegister;
        }

        public async Task<OccurrenceRegister> GetByIdForReport(Guid id)
        {
            return await _context.OccurrenceRegisters.AsNoTracking()
                 .Include(x => x.Setor)
                 .Include(x => x.RootCauseAnalysis)
                 .ThenInclude(x => x.ActionPlainResponses)
                 .Include(x => x.RootCauseAnalysis)
                 .ThenInclude(x => x.ActionPlain)
                 .ThenInclude(x => x.Questions)
                 .Include(x => x.Occurrences)
                 .AsSplitQuery()
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<OccurrenceRegister>> GetBySetor(SetorType setor, DateTime initialDate, DateTime finalDate)
        {
            return await Task.FromResult(_context.OccurrenceRegisters
                .AsNoTracking()
                .Include(x => x.Setor)
                .Where(x => x.SetorId == setor && x.RegisterDate >= initialDate && x.RegisterDate <= finalDate));
        }

        public async Task<IQueryable<OccurrenceGroup>> GetGroupBySetor(SetorType setor, int month)
        {
            var initialDate = new DateTime(DateTime.Now.Year, month, 1);
            var finalDate = new DateTime(DateTime.Now.Year, month, DateTime.DaysInMonth(DateTime.Now.Year, month));
            var nonCompliances = await GetBySetor(setor, initialDate, finalDate);

            return nonCompliances
                .SelectMany(x => x.Occurrences)
                .GroupBy(x => x.Description)
                .Select(x => new OccurrenceGroup
                {
                    Occurrence = x.Key,
                    Quantity = x.Count()
                });
        }

        public Task<OccurrenceRegister> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

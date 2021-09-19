using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Ocurrences.Data.Repositories
{
    public class NonComplianceRegisterRepository : BaseRepository<NonComplianceRegister, int>, INonComplianceRegisterRepository
    {
        private readonly OcurrencesContext _context;
        public NonComplianceRegisterRepository(OcurrencesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<NonComplianceRegister> GetByIdWithInclude(int id)
        {
            var nonComplianceRegister = await _context.NonComplianceRegisters.AsNoTracking()
                 .Include(x => x.Setor)
                 .Include(x => x.RootCauseAnalysis)
                 .Include(x => x.NonCompliances)
                 .Include(x => x.NonCompliances)
                 .ThenInclude(x => x.TypeNonCompliance)
                 .FirstOrDefaultAsync(x => x.Id == id);


            nonComplianceRegister.NonCompliances
                .Select(x => FillArchive(nonComplianceRegister.Id, x))
                .ToList();


            return nonComplianceRegister;
        }

        private NonCompliance FillArchive(int nonComplianceRegisterId,
                                          NonCompliance nonCompliance)
        {
            nonCompliance.Archives = _context.Archives
                .Where(x => x.NonComplianceId == nonCompliance.Id &&
                            x.NonComplianceRegisterId == nonComplianceRegisterId)
                .ToList();
            return nonCompliance;
        }

        public async Task<NonComplianceRegister> GetByIdForReport(int id)
        {
            return await _context.NonComplianceRegisters.AsNoTracking()
                 .Include(x => x.Setor)
                 .Include(x => x.RootCauseAnalysis)
                 .ThenInclude(x => x.ActionPlainResponses)
                 .Include(x => x.RootCauseAnalysis)
                 .ThenInclude(x => x.ActionPlain)
                 .ThenInclude(x => x.Questions)
                 .Include(x => x.NonCompliances)
                 .ThenInclude(x => x.TypeNonCompliance)
                 .AsSplitQuery()
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<NonComplianceRegister>> GetBySetor(SetorType setor, DateTime initialDate, DateTime finalDate)
        {
            return await Task.FromResult(_context.NonComplianceRegisters
                .AsNoTracking()
                .Include(x => x.Setor)
                .Where(x => x.SetorId == setor && x.RegisterDate >= initialDate && x.RegisterDate <= finalDate));
        }

        public async Task<IQueryable<NonComplianceRegisterGroup>> GetGroupBySetor(SetorType setor, int month)
        {
            var initialDate = new DateTime(DateTime.Now.Year, month, 1);
            var finalDate = new DateTime(DateTime.Now.Year, month, DateTime.DaysInMonth(DateTime.Now.Year, month));
            var nonCompliances = await GetBySetor(setor, initialDate, finalDate);

            return nonCompliances
                .SelectMany(x => x.NonCompliances)
                .GroupBy(x => x.Description)
                .Select(x => new NonComplianceRegisterGroup
                {
                    NonCompliance = x.Key,
                    Quantity = x.Count()
                });
        }
    }
}

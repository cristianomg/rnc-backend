using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models.Helps;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class NonComplianceRegisterRepository : BaseRepository<NonComplianceRegister, int>,
                                                   INonComplianceRegisterRepository
    {
        private readonly RncContext _context;
        public NonComplianceRegisterRepository(RncContext context) : base(context)
        {
            _context = context;
        }

        public async Task<NonComplianceRegister> GetByIdWithInclude(int id)
        {
            return await _context.NonComplianceRegisters.AsNoTracking()
                 .Include(x => x.Setor)
                 .Include(x => x.User)
                 .Include(x => x.RootCauseAnalysis)
                 .Include(x => x.Archives)
                 .Include(x => x.NonCompliances)
                 .ThenInclude(x => x.TypeNonCompliance)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<NonComplianceRegister> GetByIdForReport(int id)
        {
            return await _context.NonComplianceRegisters.AsNoTracking()
                 .Include(x => x.Setor)
                 .Include(x => x.User)
                 .ThenInclude(x => x.Setor)
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

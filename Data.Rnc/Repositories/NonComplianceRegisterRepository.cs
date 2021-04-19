﻿using Data.Rnc.Context;
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
    public class NonComplianceRegisterRepository : BaseRepository<NonComplianceRegister>,
                                                   INonComplianceRegisterRepository 
    {
        private readonly RncContext _context;
        public NonComplianceRegisterRepository(RncContext context) : base(context)
        {
            _context = context;
        }

        public async Task<NonComplianceRegister> GetByIdWithInclude(int id)
        {
           return await  _context.NonComplianceRegisters.AsNoTracking()
                .Include(x=>x.NonCompliance)
                .Include(x => x.Setor)
                .Include(x => x.User)
                .Include(x=>x.RootCauseAnalysis)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<NonComplianceRegister>> GetBySetor(SetorType setor, DateTime initialDate, DateTime finalDate)
        {
            return await Task.FromResult(_context.NonComplianceRegisters
                .AsNoTracking()
                .Include(x => x.Setor)
                .Where(x => x.SetorId == setor && x.RegisterDate >= initialDate && x.RegisterDate <= finalDate ));
        }
        public async Task<IQueryable<NonComplianceRegisterGroup>> GetGroupBySetor(SetorType setor, int month)
        {
            var initialDate = new DateTime(DateTime.Now.Year, month, 1);
            var finalDate = new DateTime(DateTime.Now.Year, month, DateTime.DaysInMonth(DateTime.Now.Year, month));
            var nonCompliances = await GetBySetor(setor, initialDate, finalDate);

            return nonCompliances.GroupBy(x => x.NonCompliance.Description).Select(x => new NonComplianceRegisterGroup
            {
                NonCompliance = x.Key,
                Quantity = x.Count()
            });
        }
    }
}

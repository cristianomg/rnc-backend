﻿using Domain.Entities;
using Domain.Models.Helps;
using Domain.ValueObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface INonComplianceRegisterRepository : IBaseRepository<NonComplianceRegister, int>
    {
        Task<NonComplianceRegister> GetByIdWithInclude(int id);
        Task<IQueryable<NonComplianceRegister>> GetBySetor(SetorType setor, DateTime initialDate, DateTime finalDate);
        Task<IQueryable<NonComplianceRegisterGroup>> GetGroupBySetor(SetorType setor, int month);
        Task<NonComplianceRegister> GetByIdForReport(int id);
    }
}

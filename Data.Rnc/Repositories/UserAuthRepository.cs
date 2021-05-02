﻿using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class UserAuthRepository : BaseRepository<UserAuth, int>, IUserAuthRepository
    {
        private readonly DbSet<UserAuth> _dbSet;
        public UserAuthRepository(RncContext context) : base(context)
        {
            _dbSet = context.Set<UserAuth>();
        }

        public async Task<UserAuth> GetByEmail(string email) =>
            await _dbSet
            .AsNoTracking()
            .Include(x => x.User)
            .Include(x => x.User.UserPermission)
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}

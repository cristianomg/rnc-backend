using _4lab.Administration.Domain.Interfaces;
using _4Lab.Administration.Domain.Models;
using _4Lab.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace _4lab.Administration.Data.Repositories
{
    public class UserAuthRepository : BaseRepository<UserAuth, Guid>, IUserAuthRepository
    {
        private readonly DbSet<UserAuth> _dbSet;
        public UserAuthRepository(UserContext context) : base(context)
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

using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;
        public UserRepository(RncContext context) : base(context)
        {
            _dbSet = context.Set<User>();
        }

        public async Task<User> GetByEnrollment(string enrollment) =>
            await _dbSet.FirstOrDefaultAsync(x => x.Enrollment == enrollment);
    }
}

using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        public async Task<IQueryable<User>> GetAllDontActive()
        {
            var usersDontActive = _dbSet.AsQueryable().Where(a => a.UserAuth.Active == false).OrderBy(t => t.Name);
            return await Task.FromResult(usersDontActive);
        }

        public async Task<User> ActiveUser(string email)
        {
            var user = _dbSet.Include(n => n.UserAuth).Where(a => a.UserAuth.Email == email).FirstOrDefault();
            user.Active = true;
            user.UserAuth.Active = true;
            await Update(user);
            await SaveChanges();
            return user;
        }
        public async Task<User> GetByIdWithInclude(int id, params string[] includes)
        {
            var users = await this.GetAllWithIncludes(includes);

            return users.FirstOrDefault(x => x.Id == id);
        }
    }
}

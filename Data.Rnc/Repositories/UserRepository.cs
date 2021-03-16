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
        public IQueryable<User> ObterTodos() => _dbSet.AsQueryable().Where(a => a.UserAuth.Active == false).OrderBy(t => t.Name);
        public async Task<User> AtivarCadastro(User userAut)
        {
            var user = _dbSet.AsNoTracking().Include(n => n.UserAuth).Where(a => a.Enrollment == userAut.Enrollment).FirstOrDefault();
            user.Active = true;
            user.UserAuth.Active = true;
            await Update(user);
            await SaveChanges();
            return user;
        }
    }
}

using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEnrollment(string enrollment);
        Task<IQueryable<User>> GetAllDontActive();
        Task<User> ActiveUser(int id);
    }
}

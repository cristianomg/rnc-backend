using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserAuthRepository : IBaseRepository<UserAuth>
    {
        Task<UserAuth> GetByEmail(string email);
    }
}

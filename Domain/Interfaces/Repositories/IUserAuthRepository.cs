using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserAuthRepository : IBaseRepository<UserAuth, int>
    {
        Task<UserAuth> GetByEmail(string email);
    }
}

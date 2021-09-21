using _4Lab.Administration.Domain.Models;
using _4Lab.Core.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Administration.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        Task<User> GetByEnrollment(string enrollment);
        Task<IQueryable<User>> GetAllDontActive();
        Task<User> ActiveUser(string email);
        Task<User> GetByIdWithInclude(Guid id, params string[] includes);
        Task<User> GetByEmail(string email);
        Task DeleteUserByEmail(string email);
    }
}

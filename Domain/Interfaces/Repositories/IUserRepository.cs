﻿using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        Task<User> GetByEnrollment(string enrollment);
        Task<IQueryable<User>> GetAllDontActive();
        Task<User> ActiveUser(string email);
        Task<User> GetByIdWithInclude(int id, params string[] includes);
        Task<User> GetByEmail(string email);
        Task DeleteUserByEmail(string email);
    }
}

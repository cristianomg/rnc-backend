using _4Lab.Administration.Domain.Models;
using _4Lab.Core.Data;
using System;
using System.Threading.Tasks;

namespace _4lab.Administration.Domain.Interfaces
{
    public interface IUserAuthRepository : IBaseRepository<UserAuth, Guid>
    {
        Task<UserAuth> GetByEmail(string email);
    }
}

using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Rnc.Repositories
{
    public class UserAuthRepository : BaseRepository<UserAuth>, IUserAuthRepository
    {
        public UserAuthRepository(RncContext context) : base(context) { }
    }
}

using _4lab.Administration.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace _4lab.Administration.Application.Service
{
    public interface IUserAppService
    {
        Task<IQueryable<DtoUserActive>> GetAllDontActive();
        Task<DtoUserResponse> GetByEmail(string email);
        Task<DtoUserResponse> ActiveUser(string email);
        Task DeleteUserByEmail(string email);

        Task<bool> ChangeName(int id, DtoChangeNameInput dtoChangeName);
        Task<bool> ChangePassword(DtoChangePassword dtoChangePassword);
        Task<DtoCreateAuthResponse> CreateAuth(DtoCreateAuthInput dtoCreateAuth);
        Task<bool> CreateUser(DtoCreateUserInput createUserInput);
        Task<bool> Approved(string email);
        Task<bool> Disapproved(string email);
        Task<bool> RecoveryPassword(string email);
    }
}

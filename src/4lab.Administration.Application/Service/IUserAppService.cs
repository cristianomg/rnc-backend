using _4lab.Administration.Application.DTOs;
using System.Threading.Tasks;

namespace _4lab.Administration.Application.Service
{
    public interface IUserAppService
    {
        Task<bool> ChangeName(int id, DtoChangeNameInput dtoChangeName);
        Task<bool> ChangePassword(DtoChangePassword dtoChangePassword);
        Task<DtoCreateAuthResponse> CreateAuth(DtoCreateAuthInput dtoCreateAuth);
        Task<bool> CreateUser(DtoCreateUserInput createUserInput);
        Task<bool> Approved(string email);
        Task<bool> Disapproved(string email);
        Task<bool> RecoveryPassword(string email);
    }
}

using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateUserService : IService
    {
        Task<ResponseService> Execute
            (DtoCreateUserInput createUserInput);
    }
}

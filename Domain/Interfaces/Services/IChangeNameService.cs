using Domain.Dtos.Inputs;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IChangeNameService : IService
    {
        Task<ResponseService> Execute(int id, DtoChangeNameInput dtoChangeName);
    }
}

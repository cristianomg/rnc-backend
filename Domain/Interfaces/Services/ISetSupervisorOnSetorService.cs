using Domain.Dtos.Inputs;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISetSupervisorOnSetorService : IService
    {
        Task<ResponseService> Execute(DtoSetSupervisor createSetor);
    }
}

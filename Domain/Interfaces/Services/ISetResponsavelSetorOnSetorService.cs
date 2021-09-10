using Domain.Dtos.Inputs;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISetResponsavelSetorOnSetorService : IService
    {
        Task<ResponseService> Execute(DtoSetResponsavelSetor createSetor);
    }
}

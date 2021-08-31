using Domain.Dtos.Responses;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IGetNonComplieanceRegisterByIdService : IService
    {
        Task<ResponseService<DtoNonComplianceRegisterResponse>> Execute(int id);
    }
}

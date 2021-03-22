using Domain.Dtos.Inputs;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models.Helps;

namespace Domain.Interfaces.Services
{
    public interface ICreateNonComplianceRegisterService : IService
    {
        Task<ResponseService<NonComplianceRegister>> Execute(int userId, DtoNonComplianceRegisterInput nonCompliance);
    }
}

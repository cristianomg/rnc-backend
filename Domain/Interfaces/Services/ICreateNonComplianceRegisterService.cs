using _4lab.Ocurrences.Application.DTOs;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateNonComplianceRegisterService : IService
    {
        Task<ResponseService> Execute(DtoNonComplianceRegisterInput nonCompliance);
    }
}

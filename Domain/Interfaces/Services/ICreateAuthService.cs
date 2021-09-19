using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Application.DTOs;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateAuthService : IService
    {
        Task<ResponseService<DtoCreateAuthResponse>> Execute(DtoCreateAuthInput dtoCreateAuth);
    }
}

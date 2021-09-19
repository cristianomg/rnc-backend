using _4lab.Ocurrences.Application.DTOs;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IChangePasswordService
    {
        Task<ResponseService> Execute(DtoChangePassword dtoChangePassword);
    }
}

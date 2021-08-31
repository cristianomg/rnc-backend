using Domain.Interfaces.Services;
using Domain.Models.Helps;
using System.Net;

namespace Service.Services
{
    public abstract class AbstractService : IService
    {
        protected ResponseService GenerateErroServiceResponse
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest) =>
            new ResponseService
            {
                Message = message,
                Status = status,
                Success = false
            };
        protected ResponseService<T> GenerateErroServiceResponse<T>
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest) =>
            new ResponseService<T>
            {
                Message = message,
                Status = status,
                Success = false,
                Value = default
            };
        protected ResponseService GenerateSuccessServiceResponse
            (HttpStatusCode status = HttpStatusCode.OK) =>
            new ResponseService
            {
                Success = true,
                Status = status,
                Message = string.Empty
            };
        protected ResponseService<T> GenerateSuccessServiceResponse<T>
            (T value, HttpStatusCode status = HttpStatusCode.OK) =>
            new ResponseService<T>
            {
                Message = string.Empty,
                Status = status,
                Success = true,
                Value = value
            };
    }
}

using Domain.Entities.Helps;
using System.Net;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IService
    {
        ResponseService GenerateErroServiceResponse
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest);
        ResponseService<T> GenerateErroServiceResponse<T>
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest);
        ResponseService GenerateSuccessServiceResponse
            (HttpStatusCode status = HttpStatusCode.OK);
        ResponseService<T> GenerateSuccessServiceResponse<T>
            (T value, HttpStatusCode status = HttpStatusCode.OK);
    }
}

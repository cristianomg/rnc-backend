using System.IO;
using System.Threading.Tasks;

namespace Domain.Interfaces.Util
{
    public interface IStorageService
    {
        Task<MemoryStream> GetFileAsync(string objectKey);
        Task<bool> UploadFileAsync(string objectKey, MemoryStream fileContent);
        Task DeleteFileAsync(string objectKey);
    }
}

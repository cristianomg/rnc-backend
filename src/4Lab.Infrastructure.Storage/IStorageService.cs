using System.IO;
using System.Threading.Tasks;

namespace _4lab.Infrastructure.Storage
{
    public interface IStorageService
    {
        Task<MemoryStream> GetFileAsync(string objectKey);
        Task<bool> UploadFileAsync(string objectKey, MemoryStream fileContent);
        Task DeleteFileAsync(string objectKey);
        Task<string> GetGetPreSignedURL(string objectKey);
    }
}

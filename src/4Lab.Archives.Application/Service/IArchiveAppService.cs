using _4Lab.Archives.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _4Lab.Archives.Application.Service
{
    public interface IArchiveAppService
    {
        Task<IEnumerable<DtoCreatedArchive>> UploadMany(List<DtoCreateArchive> files);
    }
}

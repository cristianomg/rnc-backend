using _4Lab.Archives.Application.DTOs;
using _4Lab.Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _4Lab.Archives.Application.Service
{
    public interface IArchiveAppService
    {
        Task<IEnumerable<DtoCreatedArchive>> UploadMany(List<DtoCreateArchive> files);
        Task<IEnumerable<DtoCreatedArchive>> GetFilesByEntityId(EntityArchiveType entityType, Guid entityId);
    }
}

using _4lab.Infrastructure.Storage;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Archives.Application.DTOs;
using _4Lab.Archives.Domain.Interfaces;
using _4Lab.Core.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.Archives.Application.Service
{
    public class ArchiveAppService : IArchiveAppService
    {
        private readonly IStorageService _storageService;
        private readonly IArchiveRepository _archiveRepository;
        private readonly IMapper _mapper;

        public ArchiveAppService(IStorageService storageService
                               , IArchiveRepository archiveRepository
                               , IMapper mapper)
        {
            _storageService = storageService;
            _archiveRepository = archiveRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DtoCreatedArchive>> UploadMany(List<DtoCreateArchive> files)
        {
            try
            {
                if (files.Any())
                {
                    var uploadedArchives = await UploadFiles(files);

                    await _archiveRepository.InsertMany(uploadedArchives);

                    await _archiveRepository.SaveChanges();

                    return _mapper.Map<List<DtoCreatedArchive>>(uploadedArchives.ToList());
                }
                else
                {
                    return default;
                }

            }
            catch
            {
                #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                DeleteFiles(files);
                #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                throw new Exception("Erro ao fazer upload dos arquivos.");
            }
        }
        private async Task DeleteFiles(List<DtoCreateArchive> files)
        {
            foreach (var item in files)
            {
                await _storageService.DeleteFileAsync(item.FileName);
            }
        }

        private async Task<IEnumerable<Archive>> UploadFiles(List<DtoCreateArchive> files)
        {
            var archives = new List<Archive>();

            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream(Convert.FromBase64String(file.File)))
                {
                    var objectKey = $"{file.FileName}-{Guid.NewGuid()}";
                    await _storageService.UploadFileAsync(objectKey, memoryStream);

                    archives.Add(new Archive(objectKey, file.FileName, file.FileType, file.EntityType, file.EntityId));
                }
            }

            return archives;
        }

        public async Task<IEnumerable<DtoCreatedArchive>> GetFilesByEntityId(EntityArchiveType entityType, string entityId)
        {
            var archives = await _archiveRepository.GetAll();

            var filteredArchives = archives.Where(x => x.EntityType == entityType &&
                                x.EntityId == entityId).ToList();

            return await Task.WhenAll(filteredArchives.Select(async archive =>
            {
                var result = _mapper.Map<DtoCreatedArchive>(archive);

                result.Url = await _storageService.GetGetPreSignedURL(archive.Key);

                return result;
            }));
        }
    }
}

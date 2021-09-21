using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Application.Service;
using _4lab.Occurrences.Domain.Interfaces;
using _4Lab.Archives.Application.DTOs;
using _4Lab.Archives.Application.Service;
using _4Lab.Core.Enums;
using _4Lab.Orchestrator.DTOs.Inputs;
using _4Lab.Orchestrator.Interfaces;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Facades
{
    public class CreateOccurrenceRegisterFacade : ICreateOccurrenceRegisterFacade
    {
        private readonly IArchiveAppService _archiveAppService;
        private readonly IOccurrenceAppService _occurrenceAppService;
        private readonly IOccurrenceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IMapper _mapper;
        public CreateOccurrenceRegisterFacade(IArchiveAppService archiveAppService
                                             , IOccurrenceAppService occurrenceAppService
                                             , IOccurrenceRegisterRepository nonComplianceRegisterRepository
                                             , IMapper mapper)
        {
            _archiveAppService = archiveAppService;
            _occurrenceAppService = occurrenceAppService;
            _mapper = mapper;
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
        }

        public async Task<bool> Execute(DtoOccurrenceRegisteFacaderInput input)
        {
            try
            {
                var archives = input.NonCompliances
                    .Select(FillNonCompliance)
                    .SelectMany(x => x.Archives)
                    .Select(x=> _mapper.Map<DtoCreateArchive>(x))
                    .ToList();

                var uploadedArchives = await _archiveAppService
                    .UploadMany(archives);

                var occurrenceRegister = _mapper
                    .Map<DtoOccurrenceRegister>(input);

                return await _occurrenceAppService
                    .CreateOccurrenceRegister(occurrenceRegister);
            }
            catch 
            {
                throw;
            }
        }
        private DtoOccurrenceFacadeInput FillNonCompliance(DtoOccurrenceFacadeInput nonCompliance)
        {
            nonCompliance.Id = Guid.NewGuid();
            nonCompliance.Archives.Select(archive =>
            {
                archive.EntityType = EntityArchiveType.Occurrence;
                archive.EntityId = nonCompliance.Id.Value;
                return archive;
            });
            return nonCompliance;
        }
    }
}

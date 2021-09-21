using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Application.Service;
using _4lab.Ocurrences.Domain.Interfaces;
using _4Lab.Archives.Application.DTOs;
using _4Lab.Archives.Application.Service;
using _4Lab.Orchestrator.DTOs.Inputs;
using _4Lab.Orchestrator.Interfaces;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Facades
{
    public class NonComplianceRegisterFacade : INonComplianceRegisterFacade
    {
        private readonly IArchiveAppService _archiveAppService;
        private readonly IOcurrenceAppService _ocurrenceAppService;
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IMapper _mapper;
        public NonComplianceRegisterFacade(IArchiveAppService archiveAppService
                                          , IOcurrenceAppService ocurrenceAppService
                                          , INonComplianceRegisterRepository nonComplianceRegisterRepository
                                          , IMapper mapper)
        {
            _archiveAppService = archiveAppService;
            _ocurrenceAppService = ocurrenceAppService;
            _mapper = mapper;
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
        }

        public async Task<bool> Register(DtoNonComplianceRegisterInput input)
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

                var nonComplianceRegister = _mapper
                    .Map<DtoNonComplianceRegister>(input);

                return await _ocurrenceAppService
                    .CreateNonComplianceRegister(nonComplianceRegister);
            }
            catch 
            {
                throw;
            }
        }
        private DtoNonComplianceInput FillNonCompliance(DtoNonComplianceInput nonCompliance)
        {
            nonCompliance.Id = Guid.NewGuid();
            nonCompliance.Archives.Select(archive =>
            {
                archive.EntityType = Core.Enums.EntityArchiveType.NonCompliance;
                archive.EntityId = nonCompliance.Id.Value;
                return archive;
            });
            return nonCompliance;
        }
    }
}

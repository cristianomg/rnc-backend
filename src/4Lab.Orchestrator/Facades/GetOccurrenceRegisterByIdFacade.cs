using _4lab.Occurrences.Application.Service;
using _4Lab.Archives.Application.Service;
using _4Lab.Core.Enums;
using _4Lab.Orchestrator.DTOs.Response;
using _4Lab.Orchestrator.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Facades
{
    public class GetOccurrenceRegisterByIdFacade : IGetOccurrenceRegisterByIdFacade
    {
        private readonly IOccurrenceAppService _occurrenceAppService;
        private readonly IArchiveAppService _archiveAppService;
        private readonly IMapper _mapper;
        public GetOccurrenceRegisterByIdFacade(IOccurrenceAppService occurrenceAppService
                                              , IArchiveAppService archiveAppService
                                              , IMapper mapper)
        {
            _occurrenceAppService = occurrenceAppService;
            _archiveAppService = archiveAppService;
            _mapper = mapper;
        }
        public async Task<DtoOccurrenceRegisterFacadeResponse> Execute(Guid id)
        {
            var occurrenceRegister = _mapper.Map<DtoOccurrenceRegisterFacadeResponse>
                (await _occurrenceAppService.GetOccurrenceRegisterById(id));

            foreach (var occurrence in occurrenceRegister.Occurrences)
            {
                occurrence.Archives = _mapper.Map<List<DtoArchiveFacadeResponse>>
                    (await _archiveAppService.GetFilesByEntityId
                            (
                                EntityArchiveType.Occurrence,
                                occurrence.Id.Value
                            )
                    );
            }

            return occurrenceRegister;
        }
    }
}

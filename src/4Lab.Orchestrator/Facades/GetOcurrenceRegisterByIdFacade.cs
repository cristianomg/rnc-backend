using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Application.Service;
using _4Lab.Archives.Application.Service;
using _4Lab.Core.Enums;
using _4Lab.Orchestrator.DTOs.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Facades
{
    public class GetOcurrenceRegisterByIdFacade
    {
        private readonly IOcurrenceAppService _ocurrenceAppService;
        private readonly IArchiveAppService _archiveAppService;
        private readonly IMapper _mapper;
        public GetOcurrenceRegisterByIdFacade(IOcurrenceAppService ocurrenceAppService
                                            , IArchiveAppService archiveAppService
                                            , IMapper mapper)
        {
            _ocurrenceAppService = ocurrenceAppService;
            _archiveAppService = archiveAppService;
            _mapper = mapper;
        }
        public async Task<DtoOcurrenceRegisterFacadeResponse> Execute(Guid id)
        {
            var ocurrenceRegister = _mapper.Map<DtoOcurrenceRegisterFacadeResponse>
                (await _ocurrenceAppService.GetOcurrenceRegisterById(id));

            foreach (var ocurrence in ocurrenceRegister.Ocurrences)
            {
                ocurrence.Archives = _mapper.Map<List<DtoArchiveFacadeResponse>>
                    (await _archiveAppService.GetFilesByEntityId
                            (
                                EntityArchiveType.NonCompliance
                              , ocurrence.Id.Value
                            )
                    );
            }

            return ocurrenceRegister;
        }
    }
}

using _4lab.Administration.Application.Service;
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
        private readonly IUserAppService _userAppService;
        private readonly IArchiveAppService _archiveAppService;
        private readonly IMapper _mapper;
        public GetOccurrenceRegisterByIdFacade(IOccurrenceAppService occurrenceAppService
                                              , IArchiveAppService archiveAppService
                                              , IMapper mapper
                                              , IUserAppService userAppService)
        {
            _occurrenceAppService = occurrenceAppService;
            _archiveAppService = archiveAppService;
            _mapper = mapper;
            _userAppService = userAppService;
        }
        public async Task<DtoOccurrenceRegisterFacadeResponse> Execute(Guid id)
        {
            var ocurrence = await _occurrenceAppService.GetOccurrenceRegisterById(id);
            ocurrence.UserName = _userAppService.GetUserByIdWithInclude(ocurrence.UserId).Result.Name;
            var occurrenceRegister = _mapper.Map<DtoOccurrenceRegisterFacadeResponse>(ocurrence);

            if (occurrenceRegister == null)
                throw new Exception("Registro de ocorrencia não encontrado.");

            foreach (var occurrence in occurrenceRegister.Occurrences)
            {
                occurrence.Archives = _mapper.Map<List<DtoArchiveFacadeResponse>>
                    (await _archiveAppService.GetFilesByEntityId
                            (
                                EntityArchiveType.Occurrence,
                                occurrence.Id.Value + "-" + occurrenceRegister.Id
                            )
                    );
            }

            return occurrenceRegister;
        }
    }
}

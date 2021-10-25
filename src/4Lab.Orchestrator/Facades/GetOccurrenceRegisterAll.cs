using _4lab.Administration.Application.Service;
using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Application.Service;
using _4Lab.Archives.Application.Service;
using _4Lab.Core.Enums;
using _4Lab.Orchestrator.DTOs.Response;
using _4Lab.Orchestrator.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Facades
{
    public class GetOccurrenceRegisterAll : IGetOccurrenceRegisterAll
    {
        private readonly IUserAppService _userAppService;
        private readonly IArchiveAppService _archiveAppService;
        private readonly IMapper _mapper;
        public GetOccurrenceRegisterAll( IArchiveAppService archiveAppService
                                              , IMapper mapper
                                              , IUserAppService userAppService)
        {
            _archiveAppService = archiveAppService;
            _mapper = mapper;
            _userAppService = userAppService;
        }
        public async Task<IQueryable<DtoOccurrenceRegisterFacadeResponse>> Execute(IQueryable<DtoOccurrenceRegisterResponse> dtoOccurrences)
        {
            List<DtoOccurrenceRegisterFacadeResponse> occurrenceRegisters = new();

            foreach (var ocurrence in dtoOccurrences)
            {
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
                occurrenceRegisters.Add(occurrenceRegister);
            }

            return occurrenceRegisters.AsQueryable();
        }
    }
}

using _4lab.Occurrences.Application.DTOs;
using _4Lab.Archives.Application.DTOs;
using _4Lab.Orchestrator.DTOs.Inputs;
using _4Lab.Orchestrator.DTOs.Response;
using AutoMapper;

namespace _4Lab.Orchestrator.Mapper
{
    public class OrchestratorMapper : Profile
    {
        public OrchestratorMapper()
        {
            CreateMap<DtoArchiveFacadeInput, DtoCreateArchive>();
            CreateMap<DtoOccurrenceRegisteFacaderInput, DtoOccurrenceRegister>();

            CreateMap<DtoCreatedArchive, DtoArchiveFacadeResponse>();
            CreateMap<DtoOccurrenceResponse, DtoOccurrenceFacadeResponse>();
            CreateMap<DtoOccurrenceRegisterResponse, DtoOccurrenceRegisterFacadeResponse>();
        }
    }
}

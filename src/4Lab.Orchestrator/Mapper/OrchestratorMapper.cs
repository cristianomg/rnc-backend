using _4lab.Ocurrences.Application.DTOs;
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
            CreateMap<DtoOcurrenceRegisteFacaderInput, DtoNonComplianceRegister>();

            CreateMap<DtoCreatedArchive, DtoArchiveFacadeResponse>();
            CreateMap<DtoOcurrenceResponse, DtoOcurrenceFacadeResponse>();
            CreateMap<DtoOcurrenceRegisterResponse, DtoOcurrenceRegisterFacadeResponse>();
        }
    }
}

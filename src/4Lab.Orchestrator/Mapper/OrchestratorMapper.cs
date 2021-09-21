using _4lab.Ocurrences.Application.DTOs;
using _4Lab.Archives.Application.DTOs;
using _4Lab.Orchestrator.DTOs.Inputs;
using AutoMapper;

namespace _4Lab.Orchestrator.Mapper
{
    public class OrchestratorMapper : Profile
    {
        public OrchestratorMapper()
        {
            CreateMap<DtoArchiveInput, DtoCreateArchive>();
            CreateMap<DtoNonComplianceRegisterInput, DtoNonComplianceRegister>();
        }
    }
}

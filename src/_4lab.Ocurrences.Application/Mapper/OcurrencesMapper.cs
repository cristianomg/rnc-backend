using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Extensions;
using AutoMapper;

namespace _4lab.Ocurrences.Application.Mapper
{
    public class OcurrencesMapper : Profile
    {
        public OcurrencesMapper()
        {
            CreateMap<NonCompliance, DtoNonCompliance>()
                .ForMember(dest => dest.NameNonCompliance, opt => opt.MapFrom(src => src.TypeNonCompliance.NameNonCompliance))
                .ForMember(dest => dest.Archives, opt => opt.Ignore());

            CreateMap<NonCompliance, DtoNonComplianceResponse>()
                .ForMember(dest => dest.NameNonCompliance, opt => opt.MapFrom(src => src.TypeNonCompliance.NameNonCompliance))
                .ForMember(dest => dest.Archives, opt => opt.Ignore());

            CreateMap<Setor, DtoSetor>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Id.GetDescription()));

            CreateMap<OccurrenceClassification, DtoOccurrenceClassification>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Id.GetDescription()));

            CreateMap<NonComplianceRegister, DtoNonComplianceRegisterResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.RegisterDate))
                .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.RegisterHour))
                .ForMember(dest => dest.Setor, opt => opt.MapFrom(src => src.Setor.Name))
                .ForMember(dest => dest.PeopleInvolved, opt => opt.MapFrom(src => src.PeopleInvolved))
                .ForMember(dest => dest.HasRootCauseAnalysis, opt => opt.MapFrom(src => src.RootCauseAnalysis != null))
                .ForMember(dest => dest.OcurrencePendency, opt => opt.MapFrom(src => src.OcurrencePendency));

            CreateMap<ActionPlain, DtoActionPlainListResponse>();

            CreateMap<ActionPlain, DtoActionPlainDetailResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

            CreateMap<ActionPlainQuestion, DtoActionPlainQuestionResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.ActionPlainId, opt => opt.MapFrom(src => src.ActionPlainId));

            CreateMap<RootCauseAnalysis, DtoCreateRootCauseAnalysisResponse>()
                .ForMember(dest => dest.NonComplianceRegisterId, opt => opt.MapFrom(src => src.NonComplianceRegisterId))
                .ForMember(dest => dest.FiveWhat, opt => opt.MapFrom(src => src.FiveWhats));

            CreateMap<FiveWhat, DtoFiveWhat>()
                .ForMember(dest => dest.What, opt => opt.MapFrom(src => src.What));

            CreateMap<ActionPlainResponse, DtoActionPlainResponse>();
        }
    }
}

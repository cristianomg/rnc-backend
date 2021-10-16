using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Extensions;
using _4Lab.Occurrences.Application.DTOs;
using AutoMapper;

namespace _4lab.Occurrences.Application.Mapper
{
    public class OccurrencesMapper : Profile
    {
        public OccurrencesMapper()
        {
            CreateMap<Occurrence, DtoOccurrence>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Occurrence, DtoOccurrenceResponse>();

            CreateMap<Setor, DtoSetor>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Id.GetDescription()));

            CreateMap<OccurrenceRisk, DtoOccurrenceRisk>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Id.GetDescription()));

            CreateMap<OccurrenceRegister, DtoOccurrenceRegisterResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.RegisterDate))
                .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.RegisterHour))
                .ForMember(dest => dest.Setor, opt => opt.MapFrom(src => src.SetorId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PeopleInvolved, opt => opt.MapFrom(src => src.PeopleInvolved))
                .ForMember(dest => dest.OccurrencePendency, opt => opt.MapFrom(src => src.OccurrencePendency))
                .ForMember(dest => dest.OccurrenceTypeId, opt => opt.MapFrom(src => src.OccurrenceTypeId))
                .ForMember(dest => dest.OccurrenceType, opt => opt.MapFrom(src => src.OccurrenceTypeId.GetDescription()));

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
                .ForMember(dest => dest.OccurrenceRegisterId, opt => opt.MapFrom(src => src.OccurrenceRegisterId))
                .ForMember(dest => dest.FiveWhat, opt => opt.MapFrom(src => src.FiveWhats));

            CreateMap<FiveWhat, DtoFiveWhat>()
                .ForMember(dest => dest.What, opt => opt.MapFrom(src => src.What));

            CreateMap<ActionPlainResponse, DtoActionPlainResponse>();

            CreateMap<OccurrenceClassification, DtoOcurrenceClassification>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Id.GetDescription()));

            CreateMap<TypeOccurrence, DtoOccurrenceType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OccurrenceTypeName));
        }
    }
}

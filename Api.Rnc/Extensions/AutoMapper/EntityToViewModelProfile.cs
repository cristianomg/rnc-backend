using AutoMapper;
using Domain.Dtos.Helps;
using Domain.Dtos.Inputs;
using Domain.Dtos.Responses;
using Domain.Entities;

namespace Api.Rnc.Extensions.AutoMapper
{
    /// <summary>
    /// Responsável por registrar os mapeamentos de entidade para dto.
    /// </summary>
    public class EntityToViewModelProfile : Profile
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EntityToViewModelProfile()
        {
            CreateMap<NonCompliance, DtoNonCompliance>()
                .ForMember(dest => dest.NameNonCompliance, opt => opt.MapFrom(src => src.TypeNonCompliance.NameNonCompliance));

            CreateMap<Setor, DtoSetor >();
            CreateMap<User, DtoUserActive>()
                .ForMember(dest=>dest.Setor, opt=>opt.MapFrom(src=>src.Setor.Name))
                .ForMember(dest=>dest.CompleteName,opt=>opt.MapFrom(src=>src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserAuth.Email));
            CreateMap<NonComplianceRegister, DtoNonComplianceRegisterResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src =>src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.RegisterDate.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.RegisterHour))
                .ForMember(dest =>dest.Setor, opt=>opt.MapFrom(src=>src.Setor.Name))
                .ForMember(dest => dest.PeopleInvolved, opt => opt.MapFrom(src => src.PeopleInvolved))
                .ForMember(dest => dest.NonComplianceType,
                            opt => opt.MapFrom(src => src.NonCompliance.TypeNonCompliance.NameNonCompliance))
                .ForMember(dest => dest.NonCompliance, opt => opt.MapFrom(src => src.NonCompliance.Description))
                .ForMember(dest=>dest.HasRootCauseAnalysis, opt=>opt.MapFrom(src=>src.RootCauseAnalysis != null));

            CreateMap<RootCauseAnalysis, DtoCreateRootCauseAnalysisResponse>()
                .ForMember(dest => dest.NonComplianceRegisterId, opt => opt.MapFrom(src => src.NonComplianceRegisterId))
                .ForMember(dest => dest.Analyze, opt => opt.MapFrom(src => src.Analyze));

            CreateMap<ActionPlain, DtoActionPlainListResponse>();
            CreateMap<ActionPlain, DtoActionPlainDetailResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest=>dest.Name, opt=>opt.MapFrom(src=>src.Name))
                .ForMember(dest=>dest.Questions, opt=>opt.MapFrom(src=>src.Questions));
            CreateMap<ActionPlainQuestion, DtoActionPlainQuestionResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.ActionPlainId, opt => opt.MapFrom(src => src.ActionPlainId));
            CreateMap<RootCauseAnalysis, DtoCreateRootCauseAnalysisResponse>();
            CreateMap<ActionPlainResponse, DtoActionPlainResponse>();
        }
    }
}

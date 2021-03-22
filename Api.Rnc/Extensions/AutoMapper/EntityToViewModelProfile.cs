using AutoMapper;
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
            CreateMap<NonComplianceRegister, DtoNonComplianceRegisterResponse>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.Id))
                .ForMember(x => x.UserName, src => src.MapFrom(x => x.User.Name))
                .ForMember(x => x.Date, src => src.MapFrom(x => x.RegisterDate.ToString("dd/MM/yyyy")))
                .ForMember(x => x.Hour, src => src.MapFrom(x => x.RegisterHour))
                .ForMember(x => x.PeopleInvolved, src => src.MapFrom(x => x.PeopleInvolved))
                .ForMember(x => x.NonComplianceType,
                    src => src.MapFrom(x => x.NonCompliance.TipoNaoConformidade.NomeTipoNaoConformidade))
                .ForMember(x => x.NonCompliance, src => src.MapFrom(x => x.NonCompliance.Descricao));
        }
    }
}

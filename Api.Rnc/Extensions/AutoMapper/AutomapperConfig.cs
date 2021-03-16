using AutoMapper;
using Domain.Dtos.Helps;
using Domain.Dtos.Inputs;
using Domain.Entities;

namespace Api.Rnc.Extensions.AutoMapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<NaoConformidade, DtoNaoConformidade>()
                .ForMember(dest => dest.NomeTipoNaoConformidade, opt => opt.MapFrom(src => src.TipoNaoConformidade.NomeTipoNaoConformidade));
            CreateMap<DtoUserAtivo, User>();
            CreateMap<User, DtoUserAtivo>()
                .ForMember(dest => dest.CompleteName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserAuth.Email))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.UserAuth.Active));

        }
    }
}

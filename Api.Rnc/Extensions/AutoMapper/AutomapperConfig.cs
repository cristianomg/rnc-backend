using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Rnc.Extensions.AutoMapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<NaoConformidade, DtoNaoConformidade>()
                .ForMember(dest => dest.NomeTipoNaoConformidade, opt => opt.MapFrom(src => src.TipoNaoConformidade.NomeTipoNaoConformidade));
        }
    }
}

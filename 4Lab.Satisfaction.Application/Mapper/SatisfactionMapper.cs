using _4Lab.Satisfaction.Application.DTOs;
using _4Lab.Satisfaction.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Application.Mapper
{
    public class SatisfactionMapper : Profile
    {
        public SatisfactionMapper() 
        {
            CreateMap<DeliveryResults, DtoDeliveryResults>()
                .ReverseMap();

            CreateMap<HowSatisfied, DtoHowSatisfied>()
                .ReverseMap();

            CreateMap<OurDifferential, DtoOurDifferential>()
                .ReverseMap();

            CreateMap<OverallImpression, OverallImpression>()
                .ReverseMap();

            CreateMap<PersonalInformations, DtoPersonalInformation>()
                .ReverseMap();

            CreateMap<Reception, DtoReception>()
                .ReverseMap();

            CreateMap<Sanitation, DtoPersonalInformation>()
                .ReverseMap();

            CreateMap<TecnicalArea, DtoTecnicalArea>()
                .ReverseMap();

            CreateMap<WhySearch, DtoWhySearch>()
                .ReverseMap();

            CreateMap<SatisfactionSurvey, DtoSatisfactionSurvey>()
                .ReverseMap();

        }
    }
}

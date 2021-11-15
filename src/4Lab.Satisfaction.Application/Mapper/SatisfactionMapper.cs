using _4Lab.Core.DomainObjects.Extensions;
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
                .ForMember(dest => dest.DeliveryPunctuality, opt => opt.MapFrom(src => src.DeliveryPunctuality))
                .ForMember(dest => dest.DeliveryResultTime, opt => opt.MapFrom(src => src.DeliveryResultTime))
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum.GetDescription()))
                .ReverseMap();

            CreateMap<DtoDeliveryResults, DeliveryResults>()
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum));

            CreateMap<HowSatisfied, DtoHowSatisfied>()
                .ForMember(dest => dest.HowSatisfiedUre, opt => opt.MapFrom(src => src.HowSatisfiedUre))
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum.GetDescription()))
                .ReverseMap();

            CreateMap<DtoHowSatisfied, HowSatisfied>()
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum));

            CreateMap<OurDifferential, DtoOurDifferential>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum.GetDescription()))
                .ReverseMap();

            CreateMap<DtoOurDifferential, OurDifferential>()
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum));

            CreateMap<OverallImpression, DtoOverallIpression>()
                .ForMember(dest => dest.FriendsRecommendation, opt => opt.MapFrom(src => src.FriendsRecommendation))
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum.GetDescription()))
                .ReverseMap();

            CreateMap<DtoOverallIpression, OverallImpression>()
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum));

            CreateMap<PersonalInformations, DtoPersonalInformation>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();

            CreateMap<Reception, DtoReception>()
                .ForMember(dest => dest.AttendanceAgility, opt => opt.MapFrom(src => src.AttendanceAgility))
                .ForMember(dest => dest.WaitingTime, opt => opt.MapFrom(src => src.WaitingTime))
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum.GetDescription()))
                .ReverseMap();

            CreateMap<DtoReception, Reception>()
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum));

            CreateMap<Sanitation, DtoSanitation>()
                .ForMember(dest => dest.LocalSanitation, opt => opt.MapFrom(src => src.LocalSanitation))
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum.GetDescription()))
                .ReverseMap();

            CreateMap<DtoSanitation, Sanitation>()
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum));

            CreateMap<TecnicalArea, DtoTecnicalArea>()
                .ForMember(dest => dest.ExamOrientation, opt => opt.MapFrom(src => src.ExamOrientation))
                .ForMember(dest => dest.ProfissionalHability, opt => opt.MapFrom(src => src.ProfissionalHability))
                .ForMember(dest => dest.WaitingTime, opt => opt.MapFrom(src => src.WaitingTime))
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum.GetDescription()))
                .ReverseMap();

            CreateMap<DtoTecnicalArea, TecnicalArea>()
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum));

            CreateMap<WhySearch, DtoWhySearch>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ResearchQuestions, opt => opt.MapFrom(src => src.ResearchQuestions))
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum.GetDescription()))
                .ReverseMap();

            CreateMap<DtoWhySearch, WhySearch>()
                .ForMember(dest => dest.NomeEnum, opt => opt.MapFrom(src => src.NomeEnum));

            CreateMap<SatisfactionSurvey, DtoSatisfactionSurveyInput>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DeliveryResults, opt => opt.MapFrom(src => src.DeliveryResults))
                .ForMember(dest => dest.HowSatisfied, opt => opt.MapFrom(src => src.HowSatisfied))
                .ForMember(dest => dest.OurDifferential, opt => opt.MapFrom(src => src.OurDifferential))
                .ForMember(dest => dest.OverallImpression, opt => opt.MapFrom(src => src.OverallImpression))
                .ForMember(dest => dest.PersonalInformations, opt => opt.MapFrom(src => src.PersonalInformations))
                .ForMember(dest => dest.Reception, opt => opt.MapFrom(src => src.Reception))
                .ForMember(dest => dest.Sanitation, opt => opt.MapFrom(src => src.Sanitation))
                .ForMember(dest => dest.TecnicalArea, opt => opt.MapFrom(src => src.TecnicalArea))
                .ForMember(dest => dest.WhySearch, opt => opt.MapFrom(src => src.WhySearch))
                .ReverseMap();

            CreateMap<SatisfactionSurvey, DtoSatisfactionSurveyResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DeliveryResults, opt => opt.MapFrom(src => src.DeliveryResults))
                .ForMember(dest => dest.HowSatisfied, opt => opt.MapFrom(src => src.HowSatisfied))
                .ForMember(dest => dest.OurDifferential, opt => opt.MapFrom(src => src.OurDifferential))
                .ForMember(dest => dest.OverallImpression, opt => opt.MapFrom(src => src.OverallImpression))
                .ForMember(dest => dest.PersonalInformations, opt => opt.MapFrom(src => src.PersonalInformations))
                .ForMember(dest => dest.Reception, opt => opt.MapFrom(src => src.Reception))
                .ForMember(dest => dest.Sanitation, opt => opt.MapFrom(src => src.Sanitation))
                .ForMember(dest => dest.TecnicalArea, opt => opt.MapFrom(src => src.TecnicalArea))
                .ForMember(dest => dest.WhySearch, opt => opt.MapFrom(src => src.WhySearch))
                .ReverseMap();
        }
    }
}

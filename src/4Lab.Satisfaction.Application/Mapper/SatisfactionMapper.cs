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
                .ReverseMap();

            CreateMap<HowSatisfied, DtoHowSatisfied>()
                .ForMember(dest => dest.HowSatisfiedUre, opt => opt.MapFrom(src => src.HowSatisfiedUre))
                .ReverseMap();

            CreateMap<OurDifferential, DtoOurDifferential>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();

            CreateMap<OverallImpression, DtoOverallIpression>()
                .ForMember(dest => dest.FriendsRecommendation, opt => opt.MapFrom(src => src.FriendsRecommendation))
                .ReverseMap();

            CreateMap<PersonalInformations, DtoPersonalInformation>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();

            CreateMap<Reception, DtoReception>()
                .ForMember(dest => dest.AttendanceAgility, opt => opt.MapFrom(src => src.AttendanceAgility))
                .ForMember(dest => dest.WaitingTime, opt => opt.MapFrom(src => src.WaitingTime))
                .ReverseMap();

            CreateMap<Sanitation, DtoSanitation>()
                .ForMember(dest => dest.LocalSanitation, opt => opt.MapFrom(src => src.LocalSanitation))
                .ReverseMap();

            CreateMap<TecnicalArea, DtoTecnicalArea>()
                .ForMember(dest => dest.ExamOrientation, opt => opt.MapFrom(src => src.ExamOrientation))
                .ForMember(dest => dest.ProfissionalHability, opt => opt.MapFrom(src => src.ProfissionalHability))
                .ForMember(dest => dest.WaitingTime, opt => opt.MapFrom(src => src.WaitingTime))
                .ReverseMap();

            CreateMap<WhySearch, DtoWhySearch>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ResearchQuestions, opt => opt.MapFrom(src => src.ResearchQuestions))
                .ReverseMap();

            CreateMap<SatisfactionSurvey, DtoSatisfactionSurveyInput>()
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

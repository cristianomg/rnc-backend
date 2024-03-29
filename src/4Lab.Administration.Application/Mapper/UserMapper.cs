﻿using _4lab.Administration.Application.DTOs;
using _4Lab.Administration.Domain.Models;
using _4Lab.Core.DomainObjects.Extensions;
using AutoMapper;

namespace _4lab.Administration.Application.Mapper
{
    public class UserMapper : Profile
    {

        public UserMapper()
        {
            CreateMap<User, DtoUserResponse>()
                .ForMember(dest => dest.Setor, opt => opt.MapFrom(src => src.SetorId.GetDescription()))
                .ForMember(dest => dest.CompleteName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserAuth.Email));

            CreateMap<User, DtoSupervisor>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<User, DtoUserActive>()
                .ForMember(dest => dest.Setor, opt => opt.MapFrom(src => src.SetorId.GetDescription()))
                .ForMember(dest => dest.CompleteName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserAuth.Email));
        }
    }
}

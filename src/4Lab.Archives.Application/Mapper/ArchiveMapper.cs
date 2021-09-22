using _4lab.Occurrences.Domain.Models;
using _4Lab.Archives.Application.DTOs;
using AutoMapper;

namespace _4Lab.Archives.Application.Mapper
{
    public class ArchiveMapper : Profile
    {
        public ArchiveMapper()
        {
            CreateMap<Archive, DtoCreatedArchive>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src.FileType))
                .ForMember(dest =>dest.Url, opt=>opt.Ignore());
        }
    }
}

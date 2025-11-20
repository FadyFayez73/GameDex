using AutoMapper;
using Core.Dtos.Platforms;
using Core.Features.Platforms.Queries.Commands;
using Domain.Entities;

namespace Core.Mapping
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformDto>()
                .ForMember(dest => dest.PlatformID, opt => opt.MapFrom(src => src.PlatformID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Platform, CreatePlatformCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();

            CreateMap<Platform, UpdatePlatformCommand>()
                .ForMember(dest => dest.PlatformId, opt => opt.MapFrom(src => src.PlatformID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
        }
    }
}
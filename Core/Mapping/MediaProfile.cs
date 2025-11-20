using AutoMapper;
using Core.Dtos.Medias;
using Core.Features.Medias.Queries.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class MediaProfile : Profile
    {
        public MediaProfile() 
        {
            CreateMap<Media, MediaDto>()
                .ForMember(dest => dest.MediaID, opt => opt.MapFrom(src => src.MediaID))
                .ForMember(dest => dest.MediaType, opt => opt.MapFrom(src => src.MediaType))
                .ForMember(dest => dest.MediaPath, opt => opt.MapFrom(src => src.MediaPath))
                .ReverseMap();

            CreateMap<CreateMediaCommand, Media>()
                .ForMember(dest => dest.MediaType, opt => opt.MapFrom(src => src.MediaType))
                .ForMember(dest => dest.MediaPath, opt => opt.MapFrom(src => src.MediaPath));
        }
    }
}

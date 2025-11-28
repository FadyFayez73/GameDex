using AutoMapper;
using Application.Dtos.Albums;
using Application.Features.Albums.Queries.Commands;
using Domain.Entities;

namespace Application.Mapping
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, AlbumDto>()
                .ForMember(d => d.Songs, opt => opt.MapFrom(s => s.Songs));

            CreateMap<Song, SongDto>();

            // Commands -> Domain
            CreateMap<CreateAlbumCommand, Album>()
                .ForMember(d => d.AlbumID, opt => opt.Ignore());
            CreateMap<UpdateAlbumCommand, Album>()
                .ForMember(d => d.AlbumID, opt => opt.MapFrom(src => src.AlbumId));
        }
    }
}
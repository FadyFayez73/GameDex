using AutoMapper;
using Core.Dtos.Games;
using Core.Features.Games.Queries.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile() 
        {
            CreateMap<Game, GameForDisplayDto>()
                .ForMember(dto => dto.GameID, g => g.MapFrom(src => src.GameID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PGRating, opt => opt.MapFrom(src => src.PGRating))
                .ForMember(dest => dest.UserRating, opt => opt.MapFrom(src => src.UserRating))
                .ForMember(dest => dest.SteamPrices, opt => opt.MapFrom(src => src.SteamPrices))
                .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src => src.Medias
                    .Where(g => g.MediaType == "Cover")
                    .Select(g => g.MediaPath)
                    .FirstOrDefault()))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name).ToList()))
                .ForMember(dest => dest.Platforms, opt => opt.MapFrom(src => src.Platforms.Select(p => p.Name).ToList()));
            CreateMap<Game, GameDto>()
                .ReverseMap();
            CreateMap<CreateGameCommand, Game>();
            CreateMap<UpdateGameCommand, Game>();
        }
    }
}

using AutoMapper;
using Application.Dtos.Characters;
using Application.Features.Characters.Queries.Commands;
using Domain.Entities;

namespace Application.Mapping
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // Domain Entity to DTO
            CreateMap<Character, CharacterDto>()
                .ForMember(dest => dest.CharacterId, opt => opt.MapFrom(src => src.CharacterID));

            // Create Command to Domain Entity
            CreateMap<CreateCharacterCommand, Character>()
                .ForMember(dest => dest.CharacterID, opt => opt.Ignore())
                .ForMember(dest => dest.GameID, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.Game, opt => opt.Ignore())
                .ForMember(dest => dest.ChapterMissions, opt => opt.Ignore());

            // Update Command to Domain Entity
            CreateMap<UpdateCharacterCommand, Character>()
                .ForMember(dest => dest.CharacterID, opt => opt.MapFrom(src => src.CharacterId))
                .ForMember(dest => dest.GameID, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.Game, opt => opt.Ignore())
                .ForMember(dest => dest.ChapterMissions, opt => opt.Ignore());
        }
    }
}


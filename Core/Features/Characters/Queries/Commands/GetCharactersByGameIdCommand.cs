using Core.Dtos.Characters;
using MediatR;

namespace Core.Features.Characters.Queries.Commands
{
    public class GetCharactersByGameIdCommand : IRequest<IEnumerable<CharacterDto>>
    {
        public Guid GameId { get; set; }
    }
}


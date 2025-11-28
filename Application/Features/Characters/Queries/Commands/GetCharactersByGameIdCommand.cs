using Application.Dtos.Characters;
using MediatR;

namespace Application.Features.Characters.Queries.Commands
{
    public class GetCharactersByGameIdCommand : IRequest<IEnumerable<CharacterDto>>
    {
        public Guid GameId { get; set; }
    }
}


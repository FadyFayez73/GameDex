using Application.Dtos.Characters;
using MediatR;

namespace Application.Features.Characters.Queries.Commands
{
    public class GetCharacterByIdCommand : IRequest<CharacterDto?>
    {
        public Guid CharacterId { get; set; }
    }
}


using Core.Dtos.Characters;
using MediatR;

namespace Core.Features.Characters.Queries.Commands
{
    public class GetCharacterByIdCommand : IRequest<CharacterDto?>
    {
        public Guid CharacterId { get; set; }
    }
}


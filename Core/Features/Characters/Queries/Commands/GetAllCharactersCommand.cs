using Core.Dtos.Characters;
using MediatR;

namespace Core.Features.Characters.Queries.Commands
{
    public class GetAllCharactersCommand : IRequest<IEnumerable<CharacterDto>>
    {
    }
}


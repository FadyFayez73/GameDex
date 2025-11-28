using Application.Dtos.Characters;
using MediatR;

namespace Application.Features.Characters.Queries.Commands
{
    public class GetAllCharactersCommand : IRequest<IEnumerable<CharacterDto>>
    {
    }
}


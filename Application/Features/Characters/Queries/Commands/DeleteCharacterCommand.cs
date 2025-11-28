using MediatR;

namespace Application.Features.Characters.Queries.Commands
{
    public class DeleteCharacterCommand : IRequest<bool>
    {
        public Guid CharacterId { get; set; }
    }
}


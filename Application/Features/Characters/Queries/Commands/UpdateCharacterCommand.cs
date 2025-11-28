using MediatR;

namespace Application.Features.Characters.Queries.Commands
{
    public class UpdateCharacterCommand : IRequest<bool>
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Guid GameId { get; set; }
    }
}


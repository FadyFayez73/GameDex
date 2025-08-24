using MediatR;

namespace Core.Features.Characters.Queries.Commands
{
    public class CreateCharacterCommand : IRequest<(bool, Guid)>
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Guid GameId { get; set; }
    }
}


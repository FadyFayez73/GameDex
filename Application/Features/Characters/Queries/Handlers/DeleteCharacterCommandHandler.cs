using Application.Features.Characters.Queries.Commands;
using MediatR;
using Application.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Characters.Queries.Handlers
{
    public class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand, bool>
    {
        private readonly ICharacterServices _characterServices;

        public DeleteCharacterCommandHandler(ICharacterServices characterServices)
        {
            _characterServices = characterServices;
        }

        public async Task<bool> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            var result = await _characterServices.DeleteAsync(request.CharacterId);
            return result;
        }
    }
}


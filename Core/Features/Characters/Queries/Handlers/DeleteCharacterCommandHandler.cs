using Core.Features.Characters.Queries.Commands;
using MediatR;
using Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Characters.Queries.Handlers
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


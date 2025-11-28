using Application.Features.Characters.Queries.Commands;
using MediatR;
using Application.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Characters.Queries.Handlers
{
    public class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand, bool>
    {
        private readonly ICharacterApplication _characterApplication;

        public DeleteCharacterCommandHandler(ICharacterApplication characterApplication)
        {
            _characterApplication = characterApplication;
        }

        public async Task<bool> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            var result = await _characterApplication.DeleteAsync(request.CharacterId);
            return result;
        }
    }
}


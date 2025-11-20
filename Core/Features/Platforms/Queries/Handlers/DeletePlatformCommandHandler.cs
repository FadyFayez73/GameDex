using Core.Features.Platforms.Queries.Commands;
using MediatR;
using Services.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Platforms.Queries.Handlers
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand, bool>
    {
        private readonly IPlatformServices _platformServices;

        public DeletePlatformCommandHandler(IPlatformServices platformServices)
        {
            _platformServices = platformServices;
        }

        public async Task<bool> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.PlatformId == Guid.Empty)
                throw new ArgumentException("Invalid platform id.", nameof(request));

            var result = await _platformServices.DeleteAsync(request.PlatformId);
            return result;
        }
    }
}
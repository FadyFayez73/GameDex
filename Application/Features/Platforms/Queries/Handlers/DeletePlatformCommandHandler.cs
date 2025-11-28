using Application.Features.Platforms.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Platforms.Queries.Handlers
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand, bool>
    {
        private readonly IPlatformApplication _platformApplication;

        public DeletePlatformCommandHandler(IPlatformApplication platformApplication)
        {
            _platformApplication = platformApplication;
        }

        public async Task<bool> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.PlatformId == Guid.Empty)
                throw new ArgumentException("Invalid platform id.", nameof(request));

            var result = await _platformApplication.DeleteAsync(request.PlatformId);
            return result;
        }
    }
}
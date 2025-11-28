using Application.Features.Albums.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Albums.Queries.Handlers
{
    public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand, bool>
    {
        private readonly IAlbumApplication _albumApplication;

        public DeleteAlbumCommandHandler(IAlbumApplication albumApplication)
        {
            _albumApplication = albumApplication;
        }

        public async Task<bool> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.AlbumId == Guid.Empty)
                throw new ArgumentException("Invalid album id.", nameof(request));

            var result = await _albumApplication.DeleteAsync(request.AlbumId);
            return result;
        }
    }
}
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
        private readonly IAlbumServices _albumServices;

        public DeleteAlbumCommandHandler(IAlbumServices albumServices)
        {
            _albumServices = albumServices;
        }

        public async Task<bool> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.AlbumId == Guid.Empty)
                throw new ArgumentException("Invalid album id.", nameof(request));

            var result = await _albumServices.DeleteAsync(request.AlbumId);
            return result;
        }
    }
}
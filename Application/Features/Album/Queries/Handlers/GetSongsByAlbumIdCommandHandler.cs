using Application.Features.Albums.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Albums.Queries.Handlers
{
    public class GetSongsByAlbumIdCommandHandler : IRequestHandler<GetSongsByAlbumIdCommand, IEnumerable<Song>>
    {
        private readonly IAlbumServices _albumServices;

        public GetSongsByAlbumIdCommandHandler(IAlbumServices albumServices)
        {
            _albumServices = albumServices;
        }

        public async Task<IEnumerable<Song>> Handle(GetSongsByAlbumIdCommand request, CancellationToken cancellationToken)
        {
            var songs = await _albumServices.GetSongsByAlbumIdAsync(request.AlbumId);
            return songs;
        }
    }
}
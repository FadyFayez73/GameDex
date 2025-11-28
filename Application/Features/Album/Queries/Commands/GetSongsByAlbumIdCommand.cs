using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Features.Albums.Queries.Commands
{
    public class GetSongsByAlbumIdCommand : IRequest<IEnumerable<Song>>
    {
        public Guid AlbumId { get; set; }

        public GetSongsByAlbumIdCommand(Guid albumId) => AlbumId = albumId;
    }
}
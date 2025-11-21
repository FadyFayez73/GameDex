using MediatR;
using Core.Dtos.Albums;
using System;

namespace Core.Features.Albums.Queries.Commands
{
    public class GetAlbumByIdCommand : IRequest<AlbumDto?>
    {
        public Guid AlbumId { get; set; }

        public GetAlbumByIdCommand(Guid albumId) => AlbumId = albumId;
    }
}
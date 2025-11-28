using MediatR;
using Application.Dtos.Albums;
using System;

namespace Application.Features.Albums.Queries.Commands
{
    public class GetAlbumByIdCommand : IRequest<AlbumDto?>
    {
        public Guid AlbumId { get; set; }

        public GetAlbumByIdCommand(Guid albumId) => AlbumId = albumId;
    }
}
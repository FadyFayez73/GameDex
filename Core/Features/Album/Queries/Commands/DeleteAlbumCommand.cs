using MediatR;
using System;

namespace Core.Features.Albums.Queries.Commands
{
    public class DeleteAlbumCommand : IRequest<bool>
    {
        public Guid AlbumId { get; set; }
    }
}
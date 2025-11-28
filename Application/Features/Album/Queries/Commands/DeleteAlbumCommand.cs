using MediatR;
using System;

namespace Application.Features.Albums.Queries.Commands
{
    public class DeleteAlbumCommand : IRequest<bool>
    {
        public Guid AlbumId { get; set; }
    }
}
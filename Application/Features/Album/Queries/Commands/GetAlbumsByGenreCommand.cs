using MediatR;
using Application.Dtos.Albums;
using System.Collections.Generic;

namespace Application.Features.Albums.Queries.Commands
{
    public class GetAlbumsByGenreCommand : IRequest<IEnumerable<AlbumDto>>
    {
        public string Genre { get; set; }

        public GetAlbumsByGenreCommand(string genre) => Genre = genre;
    }
}
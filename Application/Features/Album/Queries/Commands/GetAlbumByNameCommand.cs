using MediatR;
using Application.Dtos.Albums;

namespace Application.Features.Albums.Queries.Commands
{
    public class GetAlbumByNameCommand : IRequest<AlbumDto?>
    {
        public string Name { get; set; }

        public GetAlbumByNameCommand(string name) => Name = name;
    }
}
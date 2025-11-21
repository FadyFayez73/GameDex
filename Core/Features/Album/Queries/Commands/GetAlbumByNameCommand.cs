using MediatR;
using Core.Dtos.Albums;

namespace Core.Features.Albums.Queries.Commands
{
    public class GetAlbumByNameCommand : IRequest<AlbumDto?>
    {
        public string Name { get; set; }

        public GetAlbumByNameCommand(string name) => Name = name;
    }
}
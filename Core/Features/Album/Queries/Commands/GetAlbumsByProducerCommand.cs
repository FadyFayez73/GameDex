using MediatR;
using Core.Dtos.Albums;
using System.Collections.Generic;

namespace Core.Features.Albums.Queries.Commands
{
    public class GetAlbumsByProducerCommand : IRequest<IEnumerable<AlbumDto>>
    {
        public string Producer { get; set; }

        public GetAlbumsByProducerCommand(string producer) => Producer = producer;
    }
}
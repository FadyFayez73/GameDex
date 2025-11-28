using MediatR;
using Application.Dtos.Albums;
using System.Collections.Generic;

namespace Application.Features.Albums.Queries.Commands
{
    public class GetAlbumsByProducerCommand : IRequest<IEnumerable<AlbumDto>>
    {
        public string Producer { get; set; }

        public GetAlbumsByProducerCommand(string producer) => Producer = producer;
    }
}
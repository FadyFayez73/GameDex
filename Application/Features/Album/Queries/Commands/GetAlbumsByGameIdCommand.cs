using MediatR;
using Application.Dtos.Albums;
using System;
using System.Collections.Generic;

namespace Application.Features.Albums.Queries.Commands
{
    public class GetAlbumsByGameIdCommand : IRequest<IEnumerable<AlbumDto>>
    {
        public Guid GameId { get; set; }

        public GetAlbumsByGameIdCommand(Guid gameId) => GameId = gameId;
    }
}
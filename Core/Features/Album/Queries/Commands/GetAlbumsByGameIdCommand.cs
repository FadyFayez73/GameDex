using MediatR;
using Core.Dtos.Albums;
using System;
using System.Collections.Generic;

namespace Core.Features.Albums.Queries.Commands
{
    public class GetAlbumsByGameIdCommand : IRequest<IEnumerable<AlbumDto>>
    {
        public Guid GameId { get; set; }

        public GetAlbumsByGameIdCommand(Guid gameId) => GameId = gameId;
    }
}
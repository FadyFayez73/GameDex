using Core.Dtos.Games;
using Core.Dtos.Medias;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Medias.Queries.Commands
{
    public class GetMediasByGameIdCommand : IRequest<IEnumerable<MediaDto>>
    {
        public GetMediasByGameIdCommand(Guid gameId)
        {
            GameId = gameId;
        }

        public Guid GameId { get; set; }
    }
}

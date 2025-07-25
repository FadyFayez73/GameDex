using Core.Dtos.Games;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Games.Queries.Commands
{
    public class GetGameByIdCommand : IRequest<GameDto>
    {
        public GetGameByIdCommand(Guid gameId)
        {
            GameID = gameId;
        }

        public Guid GameID { get; set; }
    }
}

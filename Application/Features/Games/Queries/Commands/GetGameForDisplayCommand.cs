using Application.Dtos.Games;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Queries.Commands
{
    public class GetGameForDisplayCommand : IRequest<GameForDisplayDto?>
    {
        public GetGameForDisplayCommand(Guid gameId)
        {
            GameID = gameId;
        }
        public Guid GameID { get; set; }
    }
}

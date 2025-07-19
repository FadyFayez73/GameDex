using Core.Dtos.Games;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Games.Queries.Commands
{
    public class GetGameByIdCommand : IRequest<GameForDisplayDto>
    {
        public GetGameByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

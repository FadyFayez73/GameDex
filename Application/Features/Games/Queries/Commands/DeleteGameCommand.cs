using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Queries.Commands
{
    public class DeleteGameCommand : IRequest<bool>
    {
        public DeleteGameCommand(Guid GameID)
        {
            this.GameID = GameID;
        }

        public Guid GameID { get; set; }
    }
}

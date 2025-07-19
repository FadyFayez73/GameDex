using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Medias.Queries.Commands
{
    public class DeleteMediaCommand : IRequest<bool>
    {
        public DeleteMediaCommand(Guid GameID)
        {
            this.GameID = GameID;
        }

        public Guid GameID { get; set; }
    }
}

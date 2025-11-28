using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medias.Queries.Commands
{
    public class UpdateMediaCommand : IRequest<bool>
    {
        public Guid MediaID { get; set; }
        public string MediaType { get; set; }
        public string MediaPath { get; set; }
        public Guid GameId { get; set; }
    }
}

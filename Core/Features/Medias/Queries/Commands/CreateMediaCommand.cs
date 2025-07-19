using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Medias.Queries.Commands
{
    public class CreateMediaCommand : IRequest<bool>
    {
        public string MediaType { get; set; }
        public string MediaPath { get; set; }
        public Guid GameId { get; set; }
    }
}

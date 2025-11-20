using Core.Dtos.Games;
using Core.Dtos.Medias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Medias.Queries.Commands
{
    public class GetMediaByIdCommand : IRequest<MediaDto>
    {
        public GetMediaByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

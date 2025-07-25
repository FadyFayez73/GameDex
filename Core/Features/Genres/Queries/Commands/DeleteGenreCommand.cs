using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Commands
{
    public class DeleteGenreCommand : IRequest<bool>
    {
        public DeleteGenreCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id = Guid.NewGuid();
    }
}

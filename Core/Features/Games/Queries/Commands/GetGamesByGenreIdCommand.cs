using Core.Dtos.Games;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Games.Queries.Commands
{
    public class GetGamesByGenreIdCommand : IRequest<IEnumerable<GameForDisplayDto>>
    {
        public GetGamesByGenreIdCommand(Guid genreId)
        {
            GenreID = genreId;
        }

        public Guid GenreID { get; }
    }
}

using Application.Dtos.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Genres.Queries.Commands
{
    public class GetGenresByGameIdCommand : IRequest<IEnumerable<GenreDto>>
    {
        public GetGenresByGameIdCommand(Guid gameId)
        {
            GameId = gameId;
        }

        public Guid GameId { get; set; }
    }
}

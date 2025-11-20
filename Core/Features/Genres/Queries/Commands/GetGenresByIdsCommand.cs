using Core.Dtos.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Commands
{
    public class GetGenresByIdsCommand : IRequest<IEnumerable<GenreDto>>
    {
        public GetGenresByIdsCommand(List<Guid> genreIds)
        {
            GenreIds = genreIds;
        }

        public List<Guid> GenreIds { get; set; }
    }
}

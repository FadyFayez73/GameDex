using Core.Dtos.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Commands
{
    public class GetGenresByNamesCommand : IRequest<IEnumerable<GenreDto>>
    {
        public GetGenresByNamesCommand(List<string> genreNames)
        {
            GenreNames = genreNames;
        }
        public List<string> GenreNames { get; set; }
    }
}

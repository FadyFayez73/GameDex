using Core.Dtos.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Commands
{
    public class GetGenreByIdCommand : IRequest<GenreDto>
    {
        public GetGenreByIdCommand(Guid id) 
        {
            GenreID = id;
        }

        public Guid GenreID { get; set; }
    }
}

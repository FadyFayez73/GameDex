using Core.Dtos.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Commands
{
    public class GetGenreByNameCommand : IRequest<GenreDto>
    {
        public GetGenreByNameCommand(string name) 
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

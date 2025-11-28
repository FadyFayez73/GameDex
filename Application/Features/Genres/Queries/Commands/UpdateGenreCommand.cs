using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Genres.Queries.Commands
{
    public class UpdateGenreCommand : IRequest<bool>
    {
        public UpdateGenreCommand(Guid genreID, string name, string description)
        {
            GenreID = genreID;
            Name = name;
            Description = description;
        }

        public Guid GenreID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

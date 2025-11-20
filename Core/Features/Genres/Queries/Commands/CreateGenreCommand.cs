using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Commands
{
    public class CreateGenreCommand : IRequest<(bool, Guid)>
    {
        public CreateGenreCommand(string name, string description) 
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
    }
}

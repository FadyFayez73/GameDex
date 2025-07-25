using Core.Dtos.Genres;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Commands
{
    public class GetAllGenresCommand : IRequest<IEnumerable<GenreDto>>
    {

    }
}

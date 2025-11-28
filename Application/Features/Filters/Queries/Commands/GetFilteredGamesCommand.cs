using Application.Dtos.Games;
using MediatR;
using Application.Dtos.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Filters.Queries.Commands
{
    public class GetFilteredGamesCommand : IRequest<IEnumerable<GameForDisplayDto>>
    {
        public GetFilteredGamesCommand(FilterModel filter) 
        {
            FilterModel = filter;
        }

        public FilterModel FilterModel { get; set; }
    }
}

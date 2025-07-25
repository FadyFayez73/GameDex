using Core.Dtos.Games;
using MediatR;
using Services.ServicesDto.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Filters.Queries.Commands
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

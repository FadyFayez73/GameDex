using AutoMapper;
using Core.Dtos.Games;
using Core.Features.Filters.Queries.Commands;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Filters.Queries.Handlers
{
    public class GetFilteredGamesCommandHandler : IRequestHandler<GetFilteredGamesCommand, IEnumerable<GameForDisplayDto>>
    {
        private readonly IFilterServices _filterServices;
        private readonly IMapper _mapper;

        public GetFilteredGamesCommandHandler(IFilterServices filterServices, IMapper mapper)
        {
            _filterServices = filterServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameForDisplayDto>> Handle(GetFilteredGamesCommand request, CancellationToken cancellationToken)
        {
            var games = await _filterServices.GetGamesByFilter(request.FilterModel);
            var gameDto = _mapper.Map<IEnumerable<GameForDisplayDto>>(games);
            return gameDto;
        }
    }
}

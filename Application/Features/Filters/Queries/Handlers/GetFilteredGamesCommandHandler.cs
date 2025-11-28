using AutoMapper;
using Application.Dtos.Games;
using Application.Features.Filters.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Filters.Queries.Handlers
{
    public class GetFilteredGamesCommandHandler : IRequestHandler<GetFilteredGamesCommand, IEnumerable<GameForDisplayDto>>
    {
        private readonly IFilterApplication _filterApplication;
        private readonly IMapper _mapper;

        public GetFilteredGamesCommandHandler(IFilterApplication filterApplication, IMapper mapper)
        {
            _filterApplication = filterApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameForDisplayDto>> Handle(GetFilteredGamesCommand request, CancellationToken cancellationToken)
        {
            var games = await _filterApplication.GetGamesByFilter(request.FilterModel);
            var gameDto = _mapper.Map<IEnumerable<GameForDisplayDto>>(games);
            return gameDto;
        }
    }
}

using AutoMapper;
using Core.Dtos.Games;
using Core.Features.Games.Queries.Commands;
using MediatR;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Games.Queries.Handlers
{
    public class FilterGamesCommandHandler
        : IRequestHandler<FilterGamesCommand, IEnumerable<GameForDisplayDto>>
    {
        private readonly IGameServices _gameServices;
        private readonly IMapper _mapper;

        public FilterGamesCommandHandler(IGameServices gameServices, IMapper mapper)
        {
            _gameServices = gameServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameForDisplayDto>> Handle(FilterGamesCommand request, CancellationToken cancellationToken)
        {
            // Get all games first and map to DTO
            var games = await _gameServices.GetAllGamesForDisplayAsync();
            var gamesDto = _mapper.Map<IEnumerable<GameForDisplayDto>>(games).ToList();

            // Apply checkbox filters
            if (request.Checkboxes != null)
            {
                // Filter by genres
                if (request.Checkboxes.Genres != null && request.Checkboxes.Genres.Any())
                {
                    gamesDto = gamesDto.Where(g => g.Genres != null &&
                        g.Genres.Any(genreName => request.Checkboxes.Genres.Contains(genreName)))
                        .ToList();
                }

                // Filter by platforms
                if (request.Checkboxes.Platforms != null && request.Checkboxes.Platforms.Any())
                {
                    gamesDto = gamesDto.Where(g => g.Platforms != null &&
                        g.Platforms.Any(platformName => request.Checkboxes.Platforms.Contains(platformName)))
                        .ToList();
                }
            }

            // Apply range filters
            if (request.Range != null)
            {
                if (request.Range.Price != null)
                {
                    gamesDto = gamesDto.Where(g => g.SteamPrices >= request.Range.Price.Min &&
                                                   g.SteamPrices <= request.Range.Price.Max)
                        .ToList();
                }
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                gamesDto = request.SortBy.ToLower() switch
                {
                    "name" => gamesDto.OrderBy(g => g.Name).ToList(),
                    "price" => gamesDto.OrderBy(g => g.SteamPrices).ToList(),
                    "releasedate" => gamesDto.OrderBy(g => g.Name).ToList(), // Placeholder - adjust based on your needs
                    _ => gamesDto
                };
            }

            return gamesDto;
        }
    }
}
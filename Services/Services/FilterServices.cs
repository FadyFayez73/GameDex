using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.ServicesDto.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class FilterServices : IFilterServices
    {
        private readonly IGameRepository _gameRepository;
        public FilterServices(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<Game>> GetGamesByFilter(FilterModel filter)
        {
            var games = await _gameRepository.GetAllGamesForDisplayAsync();

            if (filter == null) return games; //Get all games if no filter is applied

            if (!string.IsNullOrEmpty(filter.SortBy))
                ApplySort(filter.SortBy, ref games);

            if (filter.Range != null)
                ApplyRangeFilters(filter.Range, ref games);

            var gameEnumerable = await games.ToListAsync();

            if (filter.Checkboxes != null)
                ApplyCheckboxFilters(filter.Checkboxes, ref gameEnumerable);

            return gameEnumerable.ToList();
        }

        private void ApplySort(string sortBy, ref IQueryable<Game> games)
        {
            switch (sortBy)
            {
                case "name":
                    games = games.OrderBy(g => g.Name);
                    break;
                case "release":
                    games = games.OrderBy(g => g.YearOfRelease);
                    break;
                case "priceLowerToHigher":
                    games = games.OrderBy(g => (double)g.SteamPrices);
                    break;
                case "priceHigherToLower":
                    games = games.OrderByDescending(g => (double)g.SteamPrices);
                    break;
                case "sizeLowerToHigher":
                    games = games.OrderBy(g => g.ActualGameSize);
                    break;
                case "sizeHigherToLower":
                    games = games.OrderByDescending(g => g.ActualGameSize);
                    break;
            }
        }

        private void ApplyCheckboxFilters(CheckboxFilters filter, ref List<Game> games)
        {
            if (filter.Genres != null && filter.Genres.Any())
                games = games.Where(g => g.Genres != null && g.Genres.Any(g => filter.Genres.Contains(g.Name))).ToList();
            //if (filter.Platforms != null && filter.Platforms.Any())
            //    games = games
            //        .Where(g => g.Platforms != null && g.Platforms
            //        .Any(p => filter.Platforms
            //        .Contains(p.Name))).ToList();
        }

        private void ApplyRangeFilters(RangeFilters range, ref IQueryable<Game> games)
        {
            if (range != null)
            {
                if (range.Price != null)
                {
                    games = games
                        .Where(g => (double)g.SteamPrices >= range.Price.Min &&
                                     (double)g.SteamPrices <= range.Price.Max);
                }
                //if (filter.Range.Size != null)
                //{
                //    games = games
                //        .Where(g => g.ActualGameSize >= filter.Range.Size.Min &&
                //                     g.ActualGameSize <= filter.Range.Size.Max);
                //}
            }
        }
    }
}

using Application.Dtos.Games;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Games.Queries.Commands
{
    public class FilterGamesCommand : IRequest<IEnumerable<GameForDisplayDto>>
    {
        public FilterCheckboxes? Checkboxes { get; set; }
        public FilterRange? Range { get; set; }
        public string? SortBy { get; set; }
    }

    public class FilterCheckboxes
    {
        public List<string>? Genres { get; set; }
        public List<string>? Platforms { get; set; }
        public List<string>? Tags { get; set; }
    }

    public class FilterRange
    {
        public RangeValue? Price { get; set; }
        public RangeValue? Size { get; set; }
    }

    public class RangeValue
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }
}

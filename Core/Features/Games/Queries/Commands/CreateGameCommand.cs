using MediatR;

namespace Core.Features.Games.Queries.Commands
{
    public class CreateGameCommand : IRequest<(bool, Guid)>
    {
        public string Name { get; set; }
        public MemoryStream Cover { get; set; } = new MemoryStream();
        //public string Patch { get; set; }
        //public string GamePath { get; set; }
        //public string YearOfRelease { get; set; }
        //public string PGRating { get; set; }
        //public string GameDescription { get; set; }
        //public string GameEngine { get; set; }
        //public string OrderOfFranchise { get; set; }
        //public string LinkForCrack { get; set; }
        //public decimal CriticsRating { get; set; }
        //public decimal PlayersRating { get; set; }
        //public decimal UserRating { get; set; }
        //public decimal SteamPrices { get; set; }
        //public string ActualGameSize { get; set; }
        //public string GameFiles { get; set; }
        //public int HoursToComplete { get; set; }
        //public int PlayerHours { get; set; }
        //public string StoryPlace { get; set; }
    }
}

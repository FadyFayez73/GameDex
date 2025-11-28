using Application.Contracts.Base;
using Domain.Entities;

namespace Application.Contracts
{
    public interface IGameServices : IBaseServices<Game>
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<IEnumerable<Game>> GetAllGamesForDisplayAsync();
        Task<Game?> GetGameByIdAsync(Guid id);
        Task<IEnumerable<Game>> GetGamesByGenreIdAsync(Guid gameId);
    }
}

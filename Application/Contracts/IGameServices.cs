using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGameApplication : IBaseApplication<Game>
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<IEnumerable<Game>> GetAllGamesForDisplayAsync();
        Task<Game?> GetGameByIdAsync(Guid id);
        Task<IEnumerable<Game>> GetGamesByGenreIdAsync(Guid gameId);
    }
}

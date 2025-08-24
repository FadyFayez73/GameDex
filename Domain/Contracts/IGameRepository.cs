using Domain.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game?> GetGameByIdAsync(Guid id);
        Task<Game?> GetGameByNameAsync(string name);
        Task<IQueryable<Game>> GetAllGamesForDisplayAsync();
        Task<IEnumerable<Genre>> GetGenresByGameIdAsync(Guid gameId);
    }
}
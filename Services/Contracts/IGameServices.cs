using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IGameServices : IBaseServices<Game>
    {
        Task<IEnumerable<Game>> GetAllGamesForDisplayAsync();
        Task<Game?> GetGameByIdAsync(Guid id);
    }
}

using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenreServices : IBaseServices<Genre>
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre?> GetGenreByIdAsync(Guid id);
        Task<Genre?> GetGenreByNameAsync(string name);
        Task<IEnumerable<Genre>> GetGenresByGameIdAsync(Guid gameId);
        Task<IEnumerable<Genre>> GetGenresByIdsAsync(List<Guid> ids);
        Task<IEnumerable<Genre>> GetGenresByNamesAsync(List<string> names);
    }
}

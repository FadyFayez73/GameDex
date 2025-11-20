using Domain.Entities;
using Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre?> GetGenreByIdAsync(Guid id);
        Task<Genre?> GetGenreByNameAsync(string name);
        Task<IEnumerable<Game>> GetGamesByGenreIdAsync(Guid genreId);
        Task<IEnumerable<Genre>> GetGenresByIdsAsync(List<Guid> ids);
        Task<IEnumerable<Genre>> GetGenresByNamesAsync(List<string> names);
    }
}

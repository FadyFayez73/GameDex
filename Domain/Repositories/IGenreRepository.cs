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
        Task<IEnumerable<Genre>> GetGenreByIdsAsync(List<Guid> ids);
        Task<IEnumerable<Genre>> GetGenreByNamesAsync(List<string> names);
        Task<bool> AddRangeAsync(List<Genre> genres);
    }
}

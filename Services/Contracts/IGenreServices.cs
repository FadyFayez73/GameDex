using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IGenreServices : IBaseServices<Genre>
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre?> GetGenreByIdAsync(Guid id);
        Task<Genre?> GetGenreByNameAsync(string name);
    }
}

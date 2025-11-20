using Domain.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ISongRepository : IBaseRepository<Song>
    {
        Task<IEnumerable<Song>> GetAllSongsAsync();
        Task<Song?> GetSongByIdAsync(Guid id);
        Task<Song?> GetSongByNameAsync(string name);
        Task<IEnumerable<Song>> GetSongsByDiscNumberAsync(int discNumber);
        Task<IEnumerable<Song>> GetSongsByTrackNumberAsync(int trackNumber);
    }
} 
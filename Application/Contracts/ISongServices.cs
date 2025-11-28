using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ISongApplication : IBaseApplication<Song>
    {
        Task<IEnumerable<Song>> GetAllSongsAsync();
        Task<Song?> GetSongByIdAsync(Guid id);
        Task<Song?> GetSongByNameAsync(string name);
        Task<IEnumerable<Song>> GetSongsByDiscNumberAsync(int discNumber);
        Task<IEnumerable<Song>> GetSongsByTrackNumberAsync(int trackNumber);
    }
}

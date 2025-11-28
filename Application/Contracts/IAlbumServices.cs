using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAlbumApplication : IBaseApplication<Album>
    {
        Task<IEnumerable<Album>> GetAllAlbumsAsync();
        Task<Album?> GetAlbumByIdAsync(Guid id);
        Task<Album?> GetAlbumByNameAsync(string name);
        Task<IEnumerable<Album>> GetAlbumsByGameIdAsync(Guid gameId);
        Task<IEnumerable<Album>> GetAlbumsByGenreAsync(string genre);
        Task<IEnumerable<Album>> GetAlbumsByProducerAsync(string producer);
        Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(Guid albumId);
    }
}

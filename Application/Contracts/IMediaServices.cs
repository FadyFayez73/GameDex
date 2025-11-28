using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IMediaApplication : IBaseApplication<Media>
    {
        Task<IEnumerable<Media>> GetAllMediasAsync();
        Task<Media?> GetMediaByIdAsync(Guid id);
        Task<IEnumerable<Media>> GetMediasByGameIdAsync(Guid gameId);
    }
}

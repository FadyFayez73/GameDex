using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IMediaServices : IBaseServices<Media>
    {
        Task<IEnumerable<Media>> GetMediasByGameIdAsync(Guid gameId);
        Task<Media?> GetMediaByIdAsync(Guid id);
        Task<bool> UpdateListAsync(List<Media> entities);
    }
}

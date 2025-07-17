using Domain.Entities;
using Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMediaRepository : IBaseRepository<Media>
    {
        Task<IEnumerable<Media>> GetMediasByGameIdAsync(Guid gameId);
    }
}

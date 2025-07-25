using Domain.Entities;
using Services.ServicesDto.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IFilterServices
    {
        Task<IEnumerable<Game>> GetGamesByFilter(FilterModel filter);
    }
}

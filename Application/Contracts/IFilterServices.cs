using Domain.Entities;
using Application.Dtos.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IFilterServices
    {
        Task<IEnumerable<Game>> GetGamesByFilter(FilterModel filter);
    }
}

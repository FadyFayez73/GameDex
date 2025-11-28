using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Base
{
    public interface IBaseServices<T>
    {
        Task<(bool, Guid)> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);    
        Task<bool> DeleteAsync(Guid id);
    }
}

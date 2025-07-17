using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts.Base
{
    public interface IBaseServices<T>
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);    
        Task<bool> DeleteAsync(Guid id);
    }
}

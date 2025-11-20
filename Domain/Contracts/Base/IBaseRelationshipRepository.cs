using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Base
{
    public interface IBaseRelationshipRepository<T>
    {
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Base
{
    public interface IBaseRelationshipApplication<T>
    {
        Task<bool> AddAsync(T entity);
    }
}

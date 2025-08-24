using Domain.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company?> GetCompanyByIdAsync(Guid id);
        Task<Company?> GetCompanyByNameAsync(string name);
        Task<IEnumerable<Company>> GetCompaniesByGameIdAsync(Guid gameId);
        Task<IEnumerable<Company>> GetCompaniesByRoleAsync(string role);
    }
}

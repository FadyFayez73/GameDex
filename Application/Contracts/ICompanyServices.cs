using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICompanyServices : IBaseServices<Company>
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company?> GetCompanyByIdAsync(Guid id);
        Task<Company?> GetCompanyByNameAsync(string name);
        Task<IEnumerable<Company>> GetCompaniesByGameIdAsync(Guid gameId);
    }
}

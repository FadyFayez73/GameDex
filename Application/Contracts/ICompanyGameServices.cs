using Domain.Entities;
using Domain.Repositories.Base;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICompanyGameApplication : IBaseRelationshipApplication<CompanyGame>
    {
        Task<bool> DeleteAsync(CompanyGame companyGame);
        Task<CompanyGame?> GetCompanyGameByFkAsync(Guid gameId, Guid companyId, CompanyRole companyRole);
        Task<IEnumerable<CompanyGame>> GetAllCompanyGamesAsync();
        Task<IEnumerable<Game>> GetGamesByCompanyIdAsync(Guid companyId);
        Task<IEnumerable<Company>> GetCompaniesByGameIdAsync(Guid gameId);
    }
}

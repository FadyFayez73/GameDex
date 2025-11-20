using Domain.Entities;
using Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICompanyGameRepository : IBaseRelationshipRepository<CompanyGame>
    {
        Task<CompanyGame?> GetCompanyGameByPkAsync(Guid gameId, Guid companyId, CompanyRole companyRole);
        Task<IEnumerable<CompanyGame>> GetAllCompanyGamesAsync();
        Task<IEnumerable<Game>> GetGamesByCompanyIdAsync(Guid companyId);
        Task<IEnumerable<Company>> GetCompaniesByGameIdAsync(Guid gameId);
    }
}

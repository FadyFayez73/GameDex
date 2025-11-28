using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyServices(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Company entity)
        {
            var company = await _companyRepository.GetCompanyByNameAsync(entity.Name);
            if (company != null) return (false, Guid.Empty);

            entity.CompanyID = Guid.NewGuid();

            var result = await _companyRepository.AddAsync(entity);

            return (result, entity.CompanyID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(id);
            if (company == null) return false;

            return await _companyRepository.DeleteAsync(company);
        }

        public async Task<bool> UpdateAsync(Company entity)
        {
            var result = await _companyRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllCompaniesAsync();
            return companies;
        }

        public async Task<Company?> GetCompanyByIdAsync(Guid id)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(id);
            return company;
        }

        public async Task<Company?> GetCompanyByNameAsync(string name)
        {
            var company = await _companyRepository.GetCompanyByNameAsync(name);
            return company;
        }

        public async Task<IEnumerable<Company>> GetCompaniesByGameIdAsync(Guid gameId)
        {
            var companies = await _companyRepository.GetCompaniesByGameIdAsync(gameId);
            return companies;
        }
    }
}

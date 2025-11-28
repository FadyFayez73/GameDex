using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;
using System.ComponentModel.Design;

namespace Application.Application
{
    public class CompanyGameServices : ICompanyGameServices
    {
        private readonly ICompanyGameRepository _companyGameRepository;
        private readonly IGameRepository _gameRepository;
        private readonly ICompanyRepository _companyRepository;

        public CompanyGameServices(ICompanyGameRepository companyGameRepository, IGameRepository gameRepository, ICompanyRepository companyRepository)
        {
            _companyGameRepository = companyGameRepository;
            _gameRepository = gameRepository;
            _companyRepository = companyRepository;                                                                                                 
        }

        public async Task<bool> AddAsync(CompanyGame entity)
        {
            var gameExist = await _gameRepository.GetGameByIdAsync(entity.GameID);
            var companyExist = await _companyRepository.GetCompanyByIdAsync(entity.CompanyID);

            if(gameExist == null && companyExist == null) return false;

            var result = await _companyGameRepository.AddAsync(entity);
            return result;
        }

        public async Task<bool> DeleteAsync(CompanyGame companyGame)
        {
            if (companyGame == null) return false;

            var result = await _companyGameRepository.DeleteAsync(companyGame);
            return result;
        }

        public async Task<IEnumerable<CompanyGame>> GetAllCompanyGamesAsync()
        {
            var companyGames = await _companyGameRepository.GetAllCompanyGamesAsync();
            return companyGames;
        }

        public async Task<IEnumerable<Company>> GetCompaniesByGameIdAsync(Guid gameId)
        {
            var companies = await _companyGameRepository.GetCompaniesByGameIdAsync(gameId);
            return companies;
        }

        public async Task<CompanyGame?> GetCompanyGameByFkAsync(Guid gameId, Guid companyId, CompanyRole companyRole)
        {
            var companyGame = await _companyGameRepository.GetCompanyGameByPkAsync(gameId, companyId, companyRole);
            return companyGame;
        }

        public async Task<IEnumerable<Game>> GetGamesByCompanyIdAsync(Guid companyId)
        {
            var games = await _companyGameRepository.GetGamesByCompanyIdAsync(companyId);
            return games;
        }
    }
}

using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ModuleInfrastructureDependence
    {
        public static IServiceCollection AddInfrastructureDependence(this IServiceCollection services)
        {
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IMediaRepository, MediaRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICompanyGameRepository, CompanyGameRepository>();
            services.AddTransient<IChapterMissionRepository, ChapterMissionRepository>();
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IPerformanceRepository, PerformanceRepository>();
            services.AddTransient<IPlatformRepository, PlatformRepository>();
            services.AddTransient<IRequirementRepository, RequirementRepository>();
            services.AddTransient<IControlRepository, ControlRepository>();
            services.AddTransient<IDLCRepository, DLCRepository>();
            services.AddTransient<IModManagerRepository, ModManagerRepository>();

            return services;
        }
    }
}

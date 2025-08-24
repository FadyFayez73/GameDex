using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
using Services.Services;

namespace Services
{
    public static class ModuleServicesDependence
    {
        public static IServiceCollection AddServicesDependence(this IServiceCollection services)
        {
            services.AddTransient<IGameServices, GameServices>();
            services.AddTransient<IMediaServices, MediaServices>();
            services.AddTransient<IGenreServices, GenreServices>();
            services.AddTransient<IFilterServices, FilterServices>();
            services.AddTransient<IPlatformServices, PlatformServices>();
            services.AddTransient<ICompanyServices, CompanyServices>();
            services.AddTransient<ICompanyGameServices, CompanyGameServices>();
            services.AddTransient<IChapterMissionServices, ChapterMissionServices>();
            services.AddTransient<ICharacterServices, CharacterServices>();
            services.AddTransient<IAlbumServices, AlbumServices>();
            services.AddTransient<ISongServices, SongServices>();
            services.AddTransient<IPerformanceServices, PerformanceServices>();
            services.AddTransient<IRequirementServices, RequirementServices>();
            services.AddTransient<IControlServices, ControlServices>();
            services.AddTransient<IDLCServices, DLCServices>();
            services.AddTransient<IModManagerServices, ModManagerServices>();

            return services;
        }
    }
}

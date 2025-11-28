using Microsoft.Extensions.DependencyInjection;
using Application.Contracts;
using Application.Application;

namespace Application
{
    public static class ModuleApplicationDependence
    {
        public static IServiceCollection AddApplicationDependence(this IServiceCollection Application)
        {
            Application.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            Application.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleApplicationDependence).Assembly));


            Application.AddTransient<IGameApplication, GameApplication>();
            Application.AddTransient<IMediaApplication, MediaApplication>();
            Application.AddTransient<IGenreApplication, GenreApplication>();
            Application.AddTransient<IFilterApplication, FilterApplication>();
            Application.AddTransient<IPlatformApplication, PlatformApplication>();
            Application.AddTransient<ICompanyApplication, CompanyApplication>();
            Application.AddTransient<ICompanyGameApplication, CompanyGameApplication>();
            Application.AddTransient<IChapterMissionApplication, ChapterMissionApplication>();
            Application.AddTransient<ICharacterApplication, CharacterApplication>();
            Application.AddTransient<IAlbumApplication, AlbumApplication>();
            Application.AddTransient<ISongApplication, SongApplication>();
            Application.AddTransient<IPerformanceApplication, PerformanceApplication>();
            Application.AddTransient<IRequirementApplication, RequirementApplication>();
            Application.AddTransient<IControlApplication, ControlApplication>();
            Application.AddTransient<IDLCApplication, DLCApplication>();
            Application.AddTransient<IModManagerApplication, ModManagerApplication>();

            return Application;
        }
    }
}

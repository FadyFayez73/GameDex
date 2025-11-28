using Microsoft.Extensions.DependencyInjection;
using Application.Contracts;
using Application.Application;

namespace Application
{
    public static class ModuleServicesDependence
    {
        public static IServiceCollection AddServicesDependence(this IServiceCollection Application)
        {
            Application.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            Application.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleServicesDependence).Assembly));


            Application.AddTransient<IGameServices, GameServices>();
            Application.AddTransient<IMediaServices, MedIaServices>();
            Application.AddTransient<IGenreServices, GenreServices>();
            Application.AddTransient<IFilterServices, FIlterServices>();
            Application.AddTransient<IPlatformServices, PlatformServices>();
            Application.AddTransient<ICompanyServices, CompanyServices>();
            Application.AddTransient<ICompanyGameServices, CompanyGameServices>();
            Application.AddTransient<IChapterMissionServices, ChapterMIssionServices>();
            Application.AddTransient<ICharacterServices, CharacterServices>();
            Application.AddTransient<IAlbumServices, AlbumServices>();
            Application.AddTransient<ISongServices, SongServices>();
            Application.AddTransient<IPerformanceServices, PerformanceServices>();
            Application.AddTransient<IRequirementServices, RequIrementServices>();
            Application.AddTransient<IControlServices, ControlServices>();
            Application.AddTransient<IDLCServices, DLCServices>();
            Application.AddTransient<IModManagerServices, ModManagerServices>();

            return Application;
        }
    }
}

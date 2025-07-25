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
            return services;
        }
    }
}

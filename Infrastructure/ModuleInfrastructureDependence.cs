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
            return services;
        }
    }
}

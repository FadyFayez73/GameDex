using Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ModuleInfrastructureDependence
    {
        public static IServiceProvider AddInfrastructureDependence(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>()
            // Add your infrastructure dependencies here
            // Example: services.AddScoped<IYourService, YourServiceImplementation>();
            // Return the service provider
            return services.BuildServiceProvider();
        }
}

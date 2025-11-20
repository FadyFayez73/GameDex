using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ModuleCoreDependence
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleCoreDependence).Assembly));
            return services;
        }
    }
}

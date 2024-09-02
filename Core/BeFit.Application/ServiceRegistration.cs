using BeFit.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BeFit.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(Mapping)));
            return services;
        }
    }
}

using BeFit.Application.Repositories;
using BeFit.Persistence.Contexts;
using BeFit.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeFit.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<BeFitDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}

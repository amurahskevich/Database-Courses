using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetDataBaseConnectionString();

            services.AddDbContext<ApplicationDbContext>(
                options => options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString));
        }
    }
}

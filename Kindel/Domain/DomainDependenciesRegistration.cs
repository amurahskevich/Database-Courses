using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DomainDependenciesRegistration
    {
        public static void RegistrationDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
        }
    }
}

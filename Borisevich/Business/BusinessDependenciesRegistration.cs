using Business.Animals.Services;
using Business.Cages.Services;
using Business.Employes.Services;
using Business.Kinds.Services;
using Business.Positions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessDependenciesRegistration
    {
        public static void RegistrationBusinessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<ICageService, CageService>();
            services.AddScoped<IEmployeService, EmployeService>();
            services.AddScoped<IKindService, KindService>();
            services.AddScoped<IPositionService, PositionService>();
        }
    }
}

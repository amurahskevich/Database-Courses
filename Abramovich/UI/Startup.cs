using Business.Services;
using Domain.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using UI.Controllers;
using UI.StartApplication;

namespace UI
{
    public static class Startup
    {
        public static void Run<T>()
            where T : IApplicationEntryPoint
        {
            var serviceProvider = ConfigureServices();

            var applicationEntryPoint = serviceProvider.GetRequiredService<T>();
            applicationEntryPoint.Start();
        }

        private static ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<ApplicationEntryPoint>();
            serviceCollection.AddScoped<ApplicationDbContext>();
            serviceCollection.RegisterServicesDependencies();
            serviceCollection.RegisterControllerDependencies();

            return serviceCollection.BuildServiceProvider();
        }
    }
}

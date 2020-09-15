using Business.Services.AuthorService;
using Business.Services.BookService;
using Business.Services.OrderService;
using Business.Services.StudentService;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Services
{
    public static class ServicesDependenciesRegistration
    {
        public static void RegisterServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService.AuthorService>();
            services.AddScoped<IBookService, BookService.BookService>();
            services.AddScoped<IStudentService, StudentService.StudentService>();
            services.AddScoped<IOrderService, OrderService.OrderService>();
        }
    }
}

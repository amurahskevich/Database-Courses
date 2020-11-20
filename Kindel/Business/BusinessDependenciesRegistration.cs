using Business.Categories.Services;
using Business.Departments.Services;
using Business.Employees.Services;
using Business.Projects.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessDependenciesRegistration
    {
        public static void RegistrationBusinessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IEmployService, EmployeService>();
        }
    }
}

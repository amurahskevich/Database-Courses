using Microsoft.Extensions.DependencyInjection;
using UI.Controllers.BookController;
using UI.Controllers.StudentController;

namespace UI.Controllers
{
    public static class ControllerDependenciesRegistration
    {
        public static void RegisterControllerDependencies(this IServiceCollection service)
        {
            service.AddScoped<IStudentController, StudentController.StudentController>();
            service.AddScoped<IBookController, BookController.BookController>();
        }
    }
}

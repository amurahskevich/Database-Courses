using System.Threading.Tasks;
using Business.Projects.Services;
using Contracts.Project;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await this.projectService.GetList();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var category = await this.projectService.Get(id.Value);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectDto project)
        {
            if (project.Id == 0)
            {
                await this.projectService.Create(project);
            }
            else
            {
                await this.projectService.Update(project);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.projectService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

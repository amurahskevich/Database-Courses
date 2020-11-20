using System.Threading.Tasks;
using Business.Departments.Services;
using Contracts.Department;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = await this.departmentService.GetList();

            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var department = await this.departmentService.Get(id.Value);

            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDto department)
        {
            if (department.Id == 0)
            {
                await this.departmentService.Create(department);
            }
            else
            {
                await this.departmentService.Update(department);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.departmentService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

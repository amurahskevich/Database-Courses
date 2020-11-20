using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Categories.Services;
using Business.Departments.Services;
using Business.Employees.Services;
using Business.Projects.Services;
using Contracts.Employe;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EmployeController : Controller
    {
        private readonly IEmployService employService;
        private readonly IDepartmentService departmentService;
        private readonly ICategoryService categoryService;
        private readonly IProjectService projectService;

        public EmployeController(
            IEmployService employService,
            IDepartmentService departmentService,
            ICategoryService categoryService,
            IProjectService projectService)
        {
            this.employService = employService;
            this.departmentService = departmentService;
            this.categoryService = categoryService;
            this.projectService = projectService;
        }

        public async Task<IActionResult> Index(int? id = null, string type = "")
        {
            ViewBag.Departments = await this.departmentService.GetList();
            ViewBag.Categories = await this.categoryService.GetList();
            ViewBag.Project = await this.projectService.GetList();

            IReadOnlyCollection<EmployeDto> employees;
            switch (type)
            {
                case "managers":
                    employees = await this.employService.GetDepartmentHeads();
                    break;
                case "project":
                    employees = await this.employService.GetByProject(id ?? 0);
                    break;
                case "department":
                    employees = await this.employService.GetListByDepartment(id ?? 0);
                    break;
                case "category":
                    employees = await this.employService.GetListByCategory(id ?? 0);
                    break;
                default:
                    employees = await this.employService.GetList();
                    break;
            }

            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.Departments = await this.departmentService.GetList();
            ViewBag.Categories = await this.categoryService.GetList();
            ViewBag.Project = await this.projectService.GetList();

            if (id == null)
            {
                return View();
            }

            var employe = await this.employService.Get(id.Value);

            return View(employe);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeDto employe)
        {
            if (employe.Id == 0)
            {
                await this.employService.Create(employe);
            }
            else
            {
                await this.employService.Update(employe);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.employService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

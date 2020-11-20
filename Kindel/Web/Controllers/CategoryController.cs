using System.Threading.Tasks;
using Business.Categories.Services;
using Contracts.Category;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await this.categoryService.GetList();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var category = await this.categoryService.Get(id.Value);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            if (category.Id == 0)
            {
                await this.categoryService.Create(category);
            }
            else
            {
                await this.categoryService.Update(category);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.categoryService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

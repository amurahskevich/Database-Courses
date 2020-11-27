using System.Threading.Tasks;
using Business.Cages.Services;
using Contracts.Cage;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CageController : Controller
    {
        private readonly ICageService cageService;

        public CageController(ICageService cageService)
        {
            this.cageService = cageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cages = await this.cageService.GetList();

            return View(cages);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var cage = await this.cageService.Get(id.Value);

            return View(cage);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CageDto cage)
        {
            if (cage.Id == default)
            {
                await this.cageService.Create(cage);
            }
            else
            {
                await this.cageService.Update(cage);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.cageService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

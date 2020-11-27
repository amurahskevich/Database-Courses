using System.Threading.Tasks;
using Business.Animals.Services;
using Business.Employes.Services;
using Business.Positions.Services;
using Contracts.Employe;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EmployeController : Controller
    {
        private readonly IEmployeService employeService;
        private readonly IAnimalService animalService;
        private readonly IPositionService positionService;

        public EmployeController(
            IEmployeService employeService,
            IAnimalService animalService,
            IPositionService positionService)
        {
            this.employeService = employeService;
            this.animalService = animalService;
            this.positionService = positionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Animals = await this.animalService.GetList();
            var employes = await this.employeService.GetList();

            return View(employes);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.Positions = await this.positionService.GetList();
            ViewBag.Animals = await this.animalService.GetList();

            if (id == null)
            {
                return View();
            }

            var employe = await this.employeService.Get(id.Value);

            return View(employe);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeDto employe)
        {
            if (employe.Id == default)
            {
                await this.employeService.Create(employe);
            }
            else
            {
                await this.employeService.Update(employe);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.employeService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

using System.Threading.Tasks;
using Business.Animals.Services;
using Business.Cages.Services;
using Business.Employes.Services;
using Business.Kinds.Services;
using Contracts.Animal;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService animalService;
        private readonly ICageService cageService;
        private readonly IKindService kindService;
        private readonly IEmployeService employeService;

        public AnimalController(
            IAnimalService animalService,
            ICageService cageService,
            IKindService kindService,
            IEmployeService employeService)
        {
            this.animalService = animalService;
            this.cageService = cageService;
            this.kindService = kindService;
            this.employeService = employeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Employes = await this.employeService.GetList();
            var animals = await this.animalService.GetList();

            return View(animals);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.Cages = await this.cageService.GetList();
            ViewBag.Kinds = await this.kindService.GetList();
            if (id == null)
            {
                return View();
            }

            var animal = await this.animalService.Get(id.Value);

            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimalDto animal)
        {
            if (animal.Id == default)
            {
                await this.animalService.Create(animal);
            }
            else
            {
                await this.animalService.Update(animal);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.animalService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

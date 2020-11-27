using System.Threading.Tasks;
using Business.Positions.Services;
using Contracts.Position;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService positionService;

        public PositionController(IPositionService positionService)
        {
            this.positionService = positionService;
        }

        public async Task<IActionResult> Index()
        {
            var positions = await this.positionService.GetList();

            return View(positions);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var position = await this.positionService.Get(id.Value);

            return View(position);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PositionDto position)
        {
            if (position.Id == default)
            {
                await this.positionService.Create(position);
            }
            else
            {
                await this.positionService.Update(position);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.positionService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

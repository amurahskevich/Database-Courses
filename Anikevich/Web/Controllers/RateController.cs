using Business.Dto;
using Business.Services.RateService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateService rateService;

        public RateController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public async Task<IActionResult> Index()
        {
            var rates = await this.rateService.GetAll();

            return View(rates);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if(id == null)
            {
                return View();
            }
            var rate = await this.rateService.GetRateById(id.Value);

            return View(rate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RateDto rate)
        {
            if(rate.Id == 0)
            {
                await this.rateService.Create(rate);
            }
            else
            {
                await this.rateService.Update(rate);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.rateService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
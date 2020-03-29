using Business.Dto;
using Business.Services.ClietnService;
using Business.Services.RateService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        private readonly IRateService rateService;

        public ClientController(
            IClientService clientService,
            IRateService rateService)
        {
            this.clientService = clientService;
            this.rateService = rateService;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await clientService.GetAll();

            return View(clients);
        }

        [HttpGet]
        public async  Task<IActionResult> Create(int? id)
        {
            var rates = await rateService.GetAll();
            ViewBag.Rates = rates;

            if (id == null)
            {
                return View();
            }
            var cleint = await clientService.GettById(id.Value);

            return View(cleint);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDto client)
        {
            if(client.Id == 0)
            {
                await clientService.Create(client);
            }
            else
            {
                await clientService.Update(client);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await clientService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
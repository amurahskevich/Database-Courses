using Business.Dto;
using Business.Services.ClietnService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await clientService.GetAll();

            return View(clients);
        }

        [HttpGet]
        public async  Task<IActionResult> Create(int? id)
        {
            if(id == null)
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

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
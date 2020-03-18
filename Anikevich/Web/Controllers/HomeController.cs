using System.Diagnostics;
using System.Threading.Tasks;
using Business.Services.ClietnService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientService clientService;

        public HomeController(ILogger<HomeController> logger, IClientService clientService)
        {
            _logger = logger;
            this.clientService = clientService;
        }

        public IActionResult Index()
        {
            var s = clientService.GetAll().GetAwaiter().GetResult();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

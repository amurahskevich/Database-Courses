using System.Threading.Tasks;
using Business.Kinds.Services;
using Contracts.Kind;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class KindController : Controller
    {
        private readonly IKindService kindService;

        public KindController(IKindService kindService)
        {
            this.kindService = kindService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var kinds = await this.kindService.GetList();

            return View(kinds);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var kind = await this.kindService.Get(id.Value);

            return View(kind);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindDto kind)
        {
            if (kind.Id == default)
            {
                await this.kindService.Create(kind);
            }
            else
            {
                await this.kindService.Update(kind);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.kindService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

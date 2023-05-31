using Microsoft.AspNetCore.Mvc;

namespace LanchesMacDotnet6MVC.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

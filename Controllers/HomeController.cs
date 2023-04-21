using LanchesMacDotnet6MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchesMacDotnet6MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public IActionResult Index()
        {
            //TempData["Nome"] = "Antonio"; //Recupera o valor ao acessar o home e depois redireciona pra list
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
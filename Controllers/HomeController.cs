using LanchesMacDotnet6MVC.Models;
using LanchesMacDotnet6MVC.Repositories.Interfaces;
using LanchesMacDotnet6MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchesMacDotnet6MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            //TempData["Nome"] = "Antonio"; //Recupera o valor ao acessar o home e depois redireciona pra list

            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };

            return View(homeViewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
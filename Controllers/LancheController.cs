using LanchesMacDotnet6MVC.Repositories.Interfaces;
using LanchesMacDotnet6MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMacDotnet6MVC.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            this._lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            //ViewData["Titulo"] = "Todos os lanches";
            //ViewData["Data"] = DateTime.Now;

            //var totalLanches = lanches.Count();

            //ViewBag.TotalLanches = "Total de lanches: ";
            //ViewBag.Total = totalLanches;

            //var lanches = _lancheRepository.Lanches;
            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lancheListViewModel);
        }
    }
}

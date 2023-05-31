using LanchesMacDotnet6MVC.Models;
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

        public IActionResult List(string categoria)
        {
            //ViewData["Titulo"] = "Todos os lanches";
            //ViewData["Data"] = DateTime.Now;

            //var totalLanches = lanches.Count();

            //ViewBag.TotalLanches = "Total de lanches: ";
            //ViewBag.Total = totalLanches;

            //var lanches = _lancheRepository.Lanches;
            //var lancheListViewModel = new LancheListViewModel();
            //lancheListViewModel.Lanches = _lancheRepository.Lanches;
            //lancheListViewModel.CategoriaAtual = "Categoria Atual";

            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.LancheNome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Natural")).OrderBy(l => l.LancheNome);
                }
                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheListViewModel);
        }
    }
}

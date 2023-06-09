﻿using LanchesMacDotnet6MVC.Models;
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
                lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome == categoria).OrderBy(c => c.LancheNome);
                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;

            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(l => l.LancheNome.ToLower().Contains(searchString.ToLower()) );

                if (lanches.Any())
                {
                    categoriaAtual = "Lanches";
                }
                else
                {
                    categoriaAtual = "Nenhumm lanche foi encontrado";
                }
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}

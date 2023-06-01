using LanchesMacDotnet6MVC.Repositories.Interfaces;
using LanchesMacDotnet6MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMacDotnet6MVC.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoria;

        public CategoriaMenu(ICategoriaRepository categoria)
        {
            _categoria = categoria;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoria.Categorias;



            return View(categorias);
        }
    }
}

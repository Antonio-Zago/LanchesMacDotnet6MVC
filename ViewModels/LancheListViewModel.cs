using LanchesMacDotnet6MVC.Models;

namespace LanchesMacDotnet6MVC.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }

        public string CategoriaAtual { get; set; }
    }
}

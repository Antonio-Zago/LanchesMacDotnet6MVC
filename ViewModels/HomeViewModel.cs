using LanchesMacDotnet6MVC.Models;

namespace LanchesMacDotnet6MVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}

using LanchesMacDotnet6MVC.Models;

namespace LanchesMacDotnet6MVC.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}

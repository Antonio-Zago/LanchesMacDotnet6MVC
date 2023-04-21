using LanchesMacDotnet6MVC.Context;
using LanchesMacDotnet6MVC.Models;
using LanchesMacDotnet6MVC.Repositories.Interfaces;

namespace LanchesMacDotnet6MVC.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoriaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Categoria> Categorias => _appDbContext.Categorias; //Expressão lambda
    }
}

using LanchesMacDotnet6MVC.Context;
using LanchesMacDotnet6MVC.Models;
using LanchesMacDotnet6MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMacDotnet6MVC.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _appDbContext;

        public LancheRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;   
        }

        public IEnumerable<Lanche> Lanches => _appDbContext.Lanches.Include(l => l.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _appDbContext.Lanches.Where(a => a.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _appDbContext.Lanches.Where(a => a.LancheId == lancheId).FirstOrDefault();
        }
    }
}

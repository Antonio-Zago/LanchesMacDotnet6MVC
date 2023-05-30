using LanchesMacDotnet6MVC.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMacDotnet6MVC.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _appDbContext;
        public CarrinhoCompra(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public string CarrinhoCompraId { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinhoCompra(IServiceProvider serviceProvider)
        {
            //Define a sessão
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem um serviço do tipo do nosso contexto
            var context = serviceProvider.GetService<AppDbContext>();

            //Obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //Atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //Retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _appDbContext.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId
                );

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _appDbContext.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _appDbContext.CarrinhoCompraItens.SingleOrDefault(
                   s => s.Lanche.LancheId == lanche.LancheId &&
                   s.CarrinhoCompraId == CarrinhoCompraId
               );

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _appDbContext.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _appDbContext.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItens ?? _appDbContext.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Include(s => s.Lanche).ToList();
                    
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _appDbContext.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId);

            _appDbContext.RemoveRange(carrinhoItens);
            _appDbContext.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            return _appDbContext.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Select(c => c.Lanche.Preco * c.Quantidade).Sum();
        }



    }
}

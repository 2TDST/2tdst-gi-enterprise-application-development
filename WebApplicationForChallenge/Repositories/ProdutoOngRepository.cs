using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApplicationForChallenge.Models;
using WebApplicationForChallenge.Persistencia;

namespace WebApplicationForChallenge.Repositories
{
    public class ProdutoOngRepository : IProdutoOngRepository
    {
        private FabricaContext _context;

        public ProdutoOngRepository(FabricaContext context)
        {
            _context = context;
        }

        public IList<ProdutoOng> BuscarPor(Expression<Func<ProdutoOng, bool>> filtro)
        {
            return _context.ProdutoOngs.Where(filtro).ToList();
        }

        public IList<ProdutoOng> BuscarPorProduto(int id)
        {
            return (IList<ProdutoOng>)_context.ProdutoOngs
                .Where(f => f.ProdutoId == id)
                .Select(f => f.Produto)
                .ToList();
        }

        public void Cadastrar(ProdutoOng produtoOng)
        {
            _context.ProdutoOngs.Add(produtoOng);
        }

        public IList<ProdutoOng> Listar()
        {
            return _context.ProdutoOngs.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

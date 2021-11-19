using System.Collections.Generic;
using System.Linq;
using WebApplicationForChallenge.Models;
using WebApplicationForChallenge.Persistencia;

namespace WebApplicationForChallenge.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private FabricaContext _context;

        public ProdutoRepository(FabricaContext context)
        {
            _context = context;
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public IList<Produto> Listar()
        {
            return _context.Produtos.OrderBy(d => d.Nome).ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

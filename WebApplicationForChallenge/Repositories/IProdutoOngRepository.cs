using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebApplicationForChallenge.Models;

namespace WebApplicationForChallenge.Repositories
{
    public interface IProdutoOngRepository
    {
        void Cadastrar(ProdutoOng produtoOng);
        IList<ProdutoOng> Listar();
        IList<ProdutoOng> BuscarPor(Expression<Func<ProdutoOng, bool>> filtro);
        IList<ProdutoOng> BuscarPorProduto(int id);
        void Salvar();
    }
}

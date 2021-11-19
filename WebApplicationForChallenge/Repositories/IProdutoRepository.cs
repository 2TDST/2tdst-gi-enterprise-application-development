using System.Collections.Generic;
using WebApplicationForChallenge.Models;

namespace WebApplicationForChallenge.Repositories
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);
        IList<Produto> Listar();
        void Salvar();
    }
}

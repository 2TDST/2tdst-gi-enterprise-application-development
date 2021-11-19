using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplicationForChallenge.Models;

namespace WebApplicationForChallenge.Repositories
{
    public interface IOngRepository
    {
        void Cadastrar(Ong ong);
        void Atualizar(Ong ong);
        void Remover(int id);
        Ong BuscarPorId(int id);
        IList<Ong> Listar();
        IList<Ong> BuscarPor(Expression<Func<Ong, bool>> filtro);
        void Salvar();
    }
}

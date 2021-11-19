using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApplicationForChallenge.Models;
using WebApplicationForChallenge.Persistencia;

namespace WebApplicationForChallenge.Repositories
{
    public class OngRepository : IOngRepository
    {
        private FabricaContext _context;

        public OngRepository(FabricaContext context)
        {
            _context = context;
        }

        public void Atualizar(Ong ong)
        {
            _context.Ongs.Update(ong);
        }

        public IList<Ong> BuscarPor(Expression<Func<Ong, bool>> filtro)
        {
            return _context.Ongs
                .Where(filtro)
                .Include(f => f.ProdutoOngs)
                .Include(f => f.Endereco)
                .ToList();
        }

        public Ong BuscarPorId(int id)
        {
            return _context.Ongs
                .Where(f => f.Codigo == id)
                .Include(f => f.ProdutoOngs)
                .Include(f => f.Endereco)
                .FirstOrDefault();
        }

        public void Cadastrar(Ong ong)
        {
            _context.Ongs.Add(ong);
        }

        public IList<Ong> Listar()
        {
            return _context.Ongs.ToList();
        }

        public void Remover(int id)
        {
            var ong = _context.Ongs.Find(id);
            _context.Ongs.Remove(ong);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

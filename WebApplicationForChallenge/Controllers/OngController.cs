using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationForChallenge.Models;
using WebApplicationForChallenge.Persistencia;

namespace WebApplicationForChallenge.Controllers
{
    public class OngController : Controller
    {
        private FabricaContext _context;

        //Receber por injeção de dependência o Context no construtor
        public OngController(FabricaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Ong ong)
        {
            _context.Ongs.Add(ong);
            _context.SaveChanges();//commit
            TempData["msg"] = "Ong cadastrada!";
            return RedirectToAction("Index");
        }

        [HttpGet] //Abrir a página de cadastro - URL /ong/cadastrar
        public IActionResult Cadastrar()
        {
            CarregarRamos();
            return View();
        }

        private void CarregarRamos()
        {
            var lista = new List<string>(new string[] { "Perecíveis", "Não Perecíveis" });
            ViewBag.Ramo = new SelectList(lista);
        }

        [HttpPost]
        public IActionResult Editar(Ong ong)
        {
            _context.Ongs.Update(ong);
            _context.SaveChanges();
            TempData["msg"] = "Ong atualizada";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarRamos();
            var ong = _context.Ongs
                .Include(f => f.Endereco) //inclui o relacionamento
                .Where(f => f.Codigo == id) //filtro
                .FirstOrDefault(); //retorna o primeiro resultado ou null
            return View(ong);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var ong = _context.Ongs.Find(id); //pesquisa pela PK
            _context.Ongs.Remove(ong); //remove pelo objeto
            _context.SaveChanges(); //commit
            TempData["msg"] = "ong removida!";
            return RedirectToAction("Index");
        }

        public IActionResult Index(string nomeBusca)
        {
            var lista = _context.Ongs.Where(f =>
                (f.Nome.Contains(nomeBusca) || nomeBusca == null))
                .Include(f => f.Nome)
                .Include(f => f.Endereco) //Inclui o endereço no resultado da pesquisa
                .ToList(); //recupera todas as ongs
            return View(lista);
        }

    }
}
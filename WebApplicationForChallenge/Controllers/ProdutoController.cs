using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplicationForChallenge.Persistencia;
using WebApplicationForChallenge.Models;

namespace WebApplicationForChallenge.Controllers
{
    public class ProdutoController : Controller
    {
        private FabricaContext _context;

        public ProdutoController(FabricaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.produtos = _context.Produtos.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            TempData["msg"] = "Produto registrado";
            return RedirectToAction("Index");
        }
    }
}

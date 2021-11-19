using System;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForChallenge.Models;
using WebApplicationForChallenge.Repositories;
using WebApplicationForChallenge.ViewModels;

namespace WebApplicationForChallenge.Controllers
{
    public class ProdutoOngController : Controller
    {
        private IProdutoOngRepository _produtoOngRepository;

        public ProdutoOngController(IProdutoOngRepository produtoOngRepository)
        {
            _produtoOngRepository = produtoOngRepository;
        }

        public IActionResult Index()
        {
            return View(CarregarViewModel());
        }

        private ProdutoOngViewModel CarregarViewModel()
        {
            return new ProdutoOngViewModel()
            {
                Lista = _produtoOngRepository.Listar()
            };
        }

        [HttpPost]
        public IActionResult Cadastrar(ProdutoOng produtoOng)
        {
            if (ModelState.IsValid)
            {
                _produtoOngRepository.Cadastrar(produtoOng);
                _produtoOngRepository.Salvar();
                TempData["msg"] = "Produto registrado";
                return RedirectToAction("Index");
            }
            return View("Index", CarregarViewModel());
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationForChallenge.Models;

namespace WebApplicationForChallenge.ViewModels
{
    public class ProdutoViewModel
    {
        public Produto Produto { get; set; }
        public SelectList Select { get; set; }
        public IList<Produto> Lista { get; set; }
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public bool Disponivel { get; set; }
    }
}

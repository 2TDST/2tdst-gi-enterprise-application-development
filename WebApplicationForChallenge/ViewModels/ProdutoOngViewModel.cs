using System;
using System.Collections.Generic;
using WebApplicationForChallenge.Models;

namespace WebApplicationForChallenge.ViewModels
{
    public class ProdutoOngViewModel
    {
        public ProdutoOng ProdutoOng { get; set; }
        public IList<ProdutoOng> Lista { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationForChallenge.Models
{
    //Mapeia a tabela associativa
    [Table("Tbl_Produto_Ong")]
    public class ProdutoOng
    {
        public Ong Ong{ get; set; }
        public int Codigo { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}

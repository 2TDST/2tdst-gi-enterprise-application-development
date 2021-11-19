using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationForChallenge.Models
{

    [Table("Tbl_Produto")]
        public class Produto
        {
            [Column("Id"), HiddenInput]
            public int ProdutoId { get; set; }

            [Required, MaxLength(80)]
            public string Nome { get; set; }

            //N:M
            public ICollection<ProdutoOng> ProdutoOngs { get; set; }

            public bool Disponivel { get; set; }
        }
    
}

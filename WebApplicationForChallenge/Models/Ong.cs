using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationForChallenge.Models
{
    [Table("Tbl_Ong")]
    public class Ong
    {
        [Column("Id"), HiddenInput] //Define tipo de campo como hidden
        public int Codigo { get; set; }
        
        //N:M
        [Display(Name = "Nome Fantasia")]
        [Required, MaxLength(120)]
        public string Nome { get; set; }

        [Display(Name = "Ramo de Atuação")]
        public string Ramo { get; set; }

        [Display(Name = "Porte")]
        public Porte Porte { get; set; }

        //N:M
        public ICollection<ProdutoOng> ProdutoOngs { get; set; }

        //1:1
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        //? -> permite ser null
        public string Telefone { get; set; }

    }

    public enum Porte
    {        
        Pequeno, Medio, Grande
    }

}

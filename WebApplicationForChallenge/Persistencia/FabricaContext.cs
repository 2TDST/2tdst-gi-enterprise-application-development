using WebApplicationForChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationForChallenge.Persistencia
{
    //Classe que gerencia as entidades
    public class FabricaContext : DbContext
    {
        //Propriedades que representam as entidades no banco de dados
        public DbSet<Ong> Ongs { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoOng> ProdutoOngs { get; set; }

        //Construtor que rebece algumas opções, como a string de conexão
        public FabricaContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<ProdutoOng>().HasKey(f => new { f.ProdutoId, f.Codigo });

            modelBuilder.Entity<ProdutoOng>()
                .HasOne(f => f.Ong)
                .WithMany(f => f.ProdutoOngs)
                .HasForeignKey(f => f.Codigo);

            modelBuilder.Entity<ProdutoOng>()
                .HasOne(f => f.Produto)
                .WithMany(f => f.ProdutoOngs)
                .HasForeignKey(f => f.ProdutoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

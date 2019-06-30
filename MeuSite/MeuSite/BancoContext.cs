using MeuSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MeuSite
{
 public class BancoContext : DbContext
    {

        public BancoContext() : base("BancoContext")
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<PedidoProduto>().HasKey(o => new { o.PedidoId, o.ProdutoId });
        }
    }
}
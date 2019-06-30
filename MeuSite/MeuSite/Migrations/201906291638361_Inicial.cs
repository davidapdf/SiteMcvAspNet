namespace MeuSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PedidoProduto",
                c => new
                    {
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PedidoId, t.ProdutoId })
                .ForeignKey("dbo.Pedido", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoProduto", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.PedidoProduto", "PedidoId", "dbo.Pedido");
            DropIndex("dbo.PedidoProduto", new[] { "ProdutoId" });
            DropIndex("dbo.PedidoProduto", new[] { "PedidoId" });
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
            DropTable("dbo.PedidoProduto");
        }
    }
}

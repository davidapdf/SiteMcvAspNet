namespace MeuSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Obrigatoriedade : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "Descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Descricao", c => c.String());
        }
    }
}

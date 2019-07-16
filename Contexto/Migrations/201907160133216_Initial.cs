namespace Contexto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Combustivel",
                c => new
                    {
                        CombustivelId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataInclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CombustivelId);
            
            CreateTable(
                "dbo.PostoCombustivel",
                c => new
                    {
                        PostoCombustivelId = c.Int(nullable: false, identity: true),
                        PostoId = c.Int(nullable: false),
                        CombustivelId = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.PostoCombustivelId)
                .ForeignKey("dbo.Posto", t => t.PostoId)
                .ForeignKey("dbo.Combustivel", t => t.CombustivelId)
                .Index(t => t.PostoId)
                .Index(t => t.CombustivelId);
            
            CreateTable(
                "dbo.Posto",
                c => new
                    {
                        PostoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 20, scale: 15),
                        Longitude = c.Decimal(nullable: false, precision: 20, scale: 15),
                        DataInclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostoCombustivel", "CombustivelId", "dbo.Combustivel");
            DropForeignKey("dbo.PostoCombustivel", "PostoId", "dbo.Posto");
            DropIndex("dbo.PostoCombustivel", new[] { "CombustivelId" });
            DropIndex("dbo.PostoCombustivel", new[] { "PostoId" });
            DropTable("dbo.Posto");
            DropTable("dbo.PostoCombustivel");
            DropTable("dbo.Combustivel");
        }
    }
}

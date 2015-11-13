namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProCatCom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoria_id = c.Int(nullable: false, identity: true),
                        nome_categoria = c.String(),
                    })
                .PrimaryKey(t => t.categoria_id);
            
            CreateTable(
                "dbo.Comunis",
                c => new
                    {
                        ComuneId = c.Int(nullable: false, identity: true),
                        NomeRiferimento = c.String(),
                        TelRiferimento = c.String(),
                        Comune = c.String(),
                        Provincia = c.String(),
                        Regione = c.String(),
                    })
                .PrimaryKey(t => t.ComuneId);
            
            CreateTable(
                "dbo.Prodottis",
                c => new
                    {
                        prodotto_id = c.Int(nullable: false, identity: true),
                        attivo = c.Boolean(nullable: false),
                        nome_prodotto = c.String(),
                        descrizione_prodotto = c.String(),
                        prezzo_prodotto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        categoria_Id = c.Int(nullable: false),
                        utente_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.prodotto_id)
                .ForeignKey("dbo.Categories", t => t.categoria_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.utente_Id)
                .Index(t => t.categoria_Id)
                .Index(t => t.utente_Id);
            
            AlterColumn("dbo.AspNetUsers", "ComuneId", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prodottis", "utente_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Prodottis", "categoria_Id", "dbo.Categories");
            DropIndex("dbo.Prodottis", new[] { "utente_Id" });
            DropIndex("dbo.Prodottis", new[] { "categoria_Id" });
            AlterColumn("dbo.AspNetUsers", "ComuneId", c => c.String());
            DropTable("dbo.Prodottis");
            DropTable("dbo.Comunis");
            DropTable("dbo.Categories");
        }
    }
}

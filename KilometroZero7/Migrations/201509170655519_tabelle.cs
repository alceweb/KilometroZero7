namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabelle : DbMigration
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
                        comune_Id = c.Int(nullable: false, identity: true),
                        nome_comune = c.String(),
                        provincia = c.String(),
                        regione = c.String(),
                        data_registrazione = c.DateTime(nullable: false),
                        attivo = c.Boolean(nullable: false),
                        ultimo_accesso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.comune_Id);
            
            CreateTable(
                "dbo.Prodottis",
                c => new
                    {
                        prodottoId = c.Int(nullable: false, identity: true),
                        attivo = c.Boolean(nullable: false),
                        nome_prodotto = c.String(),
                        descrizione_prodotto = c.String(),
                        prezzo_prodotto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        categoria_Id = c.Int(),
                        dataInizio = c.DateTime(nullable: false),
                        dataFine = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.prodottoId)
                .ForeignKey("dbo.Categories", t => t.categoria_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.categoria_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prodottis", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Prodottis", "categoria_Id", "dbo.Categories");
            DropIndex("dbo.Prodottis", new[] { "User_Id" });
            DropIndex("dbo.Prodottis", new[] { "categoria_Id" });
            DropTable("dbo.Prodottis");
            DropTable("dbo.Comunis");
            DropTable("dbo.Categories");
        }
    }
}

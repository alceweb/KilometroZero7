namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodotti : DbMigration
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
                "dbo.Prodottis",
                c => new
                    {
                        prodotto_id = c.Int(nullable: false, identity: true),
                        utente = c.String(),
                        attivo = c.Boolean(nullable: false),
                        nome_prodotto = c.String(),
                        descrizione_prodotto = c.String(),
                        prezzo_prodotto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        categoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.prodotto_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prodottis");
            DropTable("dbo.Categories");
        }
    }
}

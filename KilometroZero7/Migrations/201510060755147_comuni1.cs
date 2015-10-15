namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comuni1 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comunis");
        }
    }
}

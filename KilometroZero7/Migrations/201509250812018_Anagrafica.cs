namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Anagrafica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nome", c => c.String());
            AddColumn("dbo.AspNetUsers", "Cognome", c => c.String());
            AddColumn("dbo.AspNetUsers", "RagioneSocieale", c => c.String());
            AddColumn("dbo.AspNetUsers", "PartitaIva", c => c.String());
            AddColumn("dbo.AspNetUsers", "Telefono", c => c.String());
            AddColumn("dbo.AspNetUsers", "Indirizzo", c => c.String());
            AddColumn("dbo.AspNetUsers", "CAP", c => c.String());
            AddColumn("dbo.AspNetUsers", "ComuneId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ComuneId");
            DropColumn("dbo.AspNetUsers", "CAP");
            DropColumn("dbo.AspNetUsers", "Indirizzo");
            DropColumn("dbo.AspNetUsers", "Telefono");
            DropColumn("dbo.AspNetUsers", "PartitaIva");
            DropColumn("dbo.AspNetUsers", "RagioneSocieale");
            DropColumn("dbo.AspNetUsers", "Cognome");
            DropColumn("dbo.AspNetUsers", "Nome");
        }
    }
}

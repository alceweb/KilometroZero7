namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anagrafica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NomeCommerciante", c => c.String());
            AddColumn("dbo.AspNetUsers", "CognomeCommerciante", c => c.String());
            AddColumn("dbo.AspNetUsers", "IndirizzoCommerciante", c => c.String());
            AddColumn("dbo.AspNetUsers", "CapCommerciante", c => c.String());
            AddColumn("dbo.AspNetUsers", "CityCommerciante", c => c.String());
            AddColumn("dbo.AspNetUsers", "TelefonoCommerciante", c => c.String());
            AddColumn("dbo.AspNetUsers", "RagioneSociale", c => c.String());
            AddColumn("dbo.AspNetUsers", "PartitaIva", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PartitaIva");
            DropColumn("dbo.AspNetUsers", "RagioneSociale");
            DropColumn("dbo.AspNetUsers", "TelefonoCommerciante");
            DropColumn("dbo.AspNetUsers", "CityCommerciante");
            DropColumn("dbo.AspNetUsers", "CapCommerciante");
            DropColumn("dbo.AspNetUsers", "IndirizzoCommerciante");
            DropColumn("dbo.AspNetUsers", "CognomeCommerciante");
            DropColumn("dbo.AspNetUsers", "NomeCommerciante");
        }
    }
}

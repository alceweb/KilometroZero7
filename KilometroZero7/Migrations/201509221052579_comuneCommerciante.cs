namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comuneCommerciante : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CityCommerciante_id", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "nome_comune_comune_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "nome_comune_comune_Id");
            AddForeignKey("dbo.AspNetUsers", "nome_comune_comune_Id", "dbo.Comunis", "comune_Id");
            DropColumn("dbo.AspNetUsers", "CityCommerciante");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CityCommerciante", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "nome_comune_comune_Id", "dbo.Comunis");
            DropIndex("dbo.AspNetUsers", new[] { "nome_comune_comune_Id" });
            DropColumn("dbo.AspNetUsers", "nome_comune_comune_Id");
            DropColumn("dbo.AspNetUsers", "CityCommerciante_id");
        }
    }
}

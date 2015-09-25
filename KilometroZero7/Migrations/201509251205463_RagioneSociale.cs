namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RagioneSociale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RagioneSociale", c => c.String());
            DropColumn("dbo.AspNetUsers", "RagioneSocieale");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RagioneSocieale", c => c.String());
            DropColumn("dbo.AspNetUsers", "RagioneSociale");
        }
    }
}

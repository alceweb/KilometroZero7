namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comuniIdNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ComuneId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ComuneId", c => c.Int(nullable: false));
        }
    }
}

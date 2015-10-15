namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comuneidint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ComuneId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ComuneId", c => c.String());
        }
    }
}

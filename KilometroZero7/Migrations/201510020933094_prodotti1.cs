namespace KilometroZero7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodotti1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prodottis", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Prodottis", "categoria_Id");
            CreateIndex("dbo.Prodottis", "User_Id");
            AddForeignKey("dbo.Prodottis", "categoria_Id", "dbo.Categories", "categoria_id", cascadeDelete: true);
            AddForeignKey("dbo.Prodottis", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prodottis", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Prodottis", "categoria_Id", "dbo.Categories");
            DropIndex("dbo.Prodottis", new[] { "User_Id" });
            DropIndex("dbo.Prodottis", new[] { "categoria_Id" });
            DropColumn("dbo.Prodottis", "User_Id");
        }
    }
}

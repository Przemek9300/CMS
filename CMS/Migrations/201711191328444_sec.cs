namespace CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sec : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Layouts", "Id", "dbo.GeneralSettings");
            DropIndex("dbo.Layouts", new[] { "Id" });
            AddColumn("dbo.GeneralSettings", "Layout_Id", c => c.Guid());
            CreateIndex("dbo.GeneralSettings", "Layout_Id");
            AddForeignKey("dbo.GeneralSettings", "Layout_Id", "dbo.Layouts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralSettings", "Layout_Id", "dbo.Layouts");
            DropIndex("dbo.GeneralSettings", new[] { "Layout_Id" });
            DropColumn("dbo.GeneralSettings", "Layout_Id");
            CreateIndex("dbo.Layouts", "Id");
            AddForeignKey("dbo.Layouts", "Id", "dbo.GeneralSettings", "Id");
        }
    }
}

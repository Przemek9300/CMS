namespace CMS.Migrations.CmsConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSubPage4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GeneralSettings", "Page4_Id", "dbo.SubPages");
            DropIndex("dbo.GeneralSettings", new[] { "Page4_Id" });
            DropColumn("dbo.GeneralSettings", "Page4_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GeneralSettings", "Page4_Id", c => c.Int());
            CreateIndex("dbo.GeneralSettings", "Page4_Id");
            AddForeignKey("dbo.GeneralSettings", "Page4_Id", "dbo.SubPages", "Id");
        }
    }
}

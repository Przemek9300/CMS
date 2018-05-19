namespace CMS.Migrations.CmsConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInPostModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeHtml = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GeneralSettings", "Page1_Id", c => c.Int());
            AddColumn("dbo.GeneralSettings", "Page2_Id", c => c.Int());
            AddColumn("dbo.GeneralSettings", "Page3_Id", c => c.Int());
            AddColumn("dbo.GeneralSettings", "Page4_Id", c => c.Int());
            CreateIndex("dbo.GeneralSettings", "Page1_Id");
            CreateIndex("dbo.GeneralSettings", "Page2_Id");
            CreateIndex("dbo.GeneralSettings", "Page3_Id");
            CreateIndex("dbo.GeneralSettings", "Page4_Id");
            AddForeignKey("dbo.GeneralSettings", "Page1_Id", "dbo.SubPages", "Id");
            AddForeignKey("dbo.GeneralSettings", "Page2_Id", "dbo.SubPages", "Id");
            AddForeignKey("dbo.GeneralSettings", "Page3_Id", "dbo.SubPages", "Id");
            AddForeignKey("dbo.GeneralSettings", "Page4_Id", "dbo.SubPages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralSettings", "Page4_Id", "dbo.SubPages");
            DropForeignKey("dbo.GeneralSettings", "Page3_Id", "dbo.SubPages");
            DropForeignKey("dbo.GeneralSettings", "Page2_Id", "dbo.SubPages");
            DropForeignKey("dbo.GeneralSettings", "Page1_Id", "dbo.SubPages");
            DropIndex("dbo.GeneralSettings", new[] { "Page4_Id" });
            DropIndex("dbo.GeneralSettings", new[] { "Page3_Id" });
            DropIndex("dbo.GeneralSettings", new[] { "Page2_Id" });
            DropIndex("dbo.GeneralSettings", new[] { "Page1_Id" });
            DropColumn("dbo.GeneralSettings", "Page4_Id");
            DropColumn("dbo.GeneralSettings", "Page3_Id");
            DropColumn("dbo.GeneralSettings", "Page2_Id");
            DropColumn("dbo.GeneralSettings", "Page1_Id");
            DropTable("dbo.SubPages");
        }
    }
}

namespace CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LayoutGeneralSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CommentsSections = c.Boolean(nullable: false),
                        ArticlesInOneView = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Layouts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralSettings", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Layouts", "Id", "dbo.GeneralSettings");
            DropIndex("dbo.Layouts", new[] { "Id" });
            DropTable("dbo.Layouts");
            DropTable("dbo.GeneralSettings");
        }
    }
}

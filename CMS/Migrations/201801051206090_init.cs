namespace CMS.Migrations.CmsConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        Layout_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layouts", t => t.Layout_Id)
                .Index(t => t.Layout_Id);
            
            CreateTable(
                "dbo.Layouts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        AllowComments = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralSettings", "Layout_Id", "dbo.Layouts");
            DropIndex("dbo.GeneralSettings", new[] { "Layout_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.Layouts");
            DropTable("dbo.GeneralSettings");
        }
    }
}

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

            CreateTable(
            "dbo.PostsTags",
            c => new
            {
                PostId = c.Guid(nullable: false),
                TagId = c.Guid(nullable: false),
            })
            .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);

        




    }



public override void Down()
        {
            DropForeignKey("dbo.PostsTags", "PostId", "dbo.PostsTags");
            DropForeignKey("dbo.PostsTags", "TagId", "dbo.Tags");

            DropForeignKey("dbo.GeneralSettings", "Layout_Id", "dbo.Layouts");
            DropIndex("dbo.GeneralSettings", new[] { "Layout_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "PostId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "TagId" });
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.PostsTags");
            DropTable("dbo.Layouts");
            DropTable("dbo.PostsTags");

            DropTable("dbo.GeneralSettings");
        }
    }
}

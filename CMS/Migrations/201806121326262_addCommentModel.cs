namespace CMS.Migrations.CmsConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Content = c.String(),
                        PublishAt = c.DateTime(nullable: false),
                        Edited = c.Boolean(nullable: false),
                        Posts_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.Posts_Id)
                .Index(t => t.Posts_Id);
            
            AddColumn("dbo.Posts", "CommentId", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Posts_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Posts_Id" });
            DropColumn("dbo.Posts", "CommentId");
            DropTable("dbo.Comments");
        }
    }
}

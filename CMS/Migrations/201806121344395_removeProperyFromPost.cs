namespace CMS.Migrations.CmsConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeProperyFromPost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "CommentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CommentId", c => c.Int());
        }
    }
}

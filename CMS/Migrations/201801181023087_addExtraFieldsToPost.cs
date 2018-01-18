namespace CMS.Migrations.CmsConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addExtraFieldsToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ImageUrl", c => c.String());
            AddColumn("dbo.Posts", "PublishAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "ModifyAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "ModifyAt");
            DropColumn("dbo.Posts", "PublishAt");
            DropColumn("dbo.Posts", "ImageUrl");
        }
    }
}

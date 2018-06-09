namespace CMS.Migrations.CmsConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewsToPost : DbMigration
    {
        public override void Up()
        {

            AddColumn("dbo.Posts", "Views", c => c.Int(nullable: false));

        }
        
        public override void Down()
        {
          
            DropColumn("dbo.Posts", "Views");
          
        }
    }
}

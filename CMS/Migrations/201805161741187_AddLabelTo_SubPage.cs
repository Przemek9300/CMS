namespace CMS.Migrations.CmsConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLabelTo_SubPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubPages", "Label", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubPages", "Label");
        }
    }
}

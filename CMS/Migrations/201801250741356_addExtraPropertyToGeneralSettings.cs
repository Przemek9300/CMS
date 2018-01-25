namespace CMS.Migrations.CmsConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addExtraPropertyToGeneralSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralSettings", "ApplicationName", c => c.String());
            AddColumn("dbo.GeneralSettings", "LogoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralSettings", "LogoUrl");
            DropColumn("dbo.GeneralSettings", "ApplicationName");
        }
    }
}

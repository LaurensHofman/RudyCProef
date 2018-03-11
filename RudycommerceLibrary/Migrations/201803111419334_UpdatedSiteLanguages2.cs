namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSiteLanguages2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.language", "local_name", c => c.String());
            AlterColumn("dbo.language", "dutch_name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.language", "dutch_name", c => c.String(maxLength: 255));
            AlterColumn("dbo.language", "local_name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}

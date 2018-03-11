namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSiteLanguages3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.language", "local_name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.language", "local_name", c => c.String());
        }
    }
}

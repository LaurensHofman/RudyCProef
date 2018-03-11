namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSiteLanguages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.language", "local_name", c => c.String());
            AddColumn("dbo.language", "dutch_name", c => c.String());
            AddColumn("dbo.language", "english_name", c => c.String());
            DropColumn("dbo.language", "language_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.language", "language_name", c => c.String());
            DropColumn("dbo.language", "english_name");
            DropColumn("dbo.language", "dutch_name");
            DropColumn("dbo.language", "local_name");
        }
    }
}

namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSiteLanguages4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.language", "dutch_name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.language", "english_name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.language", "ISO", c => c.String(nullable: false, maxLength: 3));
            CreateIndex("dbo.language", "ISO", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.language", new[] { "ISO" });
            AlterColumn("dbo.language", "ISO", c => c.String());
            AlterColumn("dbo.language", "english_name", c => c.String());
            AlterColumn("dbo.language", "dutch_name", c => c.String());
        }
    }
}

namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminVerifyUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.desktop_users", "verified_by_admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.desktop_users", "verified_by_admin");
        }
    }
}

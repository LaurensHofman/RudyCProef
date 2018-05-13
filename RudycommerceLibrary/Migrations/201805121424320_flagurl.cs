namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class flagurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.languages", "flag_icon_url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.languages", "flag_icon_url");
        }
    }
}

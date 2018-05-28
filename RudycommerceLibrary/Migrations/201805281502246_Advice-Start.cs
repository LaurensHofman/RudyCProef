namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdviceStart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.localized_property", "advice_description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.localized_property", "advice_description");
        }
    }
}

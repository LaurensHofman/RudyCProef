namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetProductPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.localized_product", "LanguageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.localized_product", "LanguageName");
        }
    }
}

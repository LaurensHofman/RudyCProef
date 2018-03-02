namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocaliedProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.localized_product", "created_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.localized_product", "modified_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.localized_product", "deleted_at", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.localized_product", "deleted_at");
            DropColumn("dbo.localized_product", "modified_at");
            DropColumn("dbo.localized_product", "created_at");
        }
    }
}

namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ripIsReq : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.category__specific_product_properties", "is_required");
        }
        
        public override void Down()
        {
            AddColumn("dbo.category__specific_product_properties", "is_required", c => c.Boolean(nullable: false));
        }
    }
}

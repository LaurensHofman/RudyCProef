namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category_properties_is_required : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.category__specific_product_properties", "is_required", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.category__specific_product_properties", "is_required");
        }
    }
}

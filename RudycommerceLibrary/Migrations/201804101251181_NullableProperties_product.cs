namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableProperties_product : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "unit_price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.products", "intial_stock", c => c.Int());
            AlterColumn("dbo.products", "current_stock", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.products", "current_stock", c => c.Int(nullable: false));
            AlterColumn("dbo.products", "intial_stock", c => c.Int(nullable: false));
            AlterColumn("dbo.products", "unit_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoProductTypes1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        is_active = c.Boolean(nullable: false),
                        initial_stock = c.Int(nullable: false),
                        current_stock = c.Int(nullable: false),
                        available_stock = c.Int(nullable: false),
                        iron_stock = c.Int(nullable: false),
                        maximum_stock = c.Int(nullable: false),
                        type_of_product = c.String(),
                        type_of_equipment = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.product");
        }
    }
}

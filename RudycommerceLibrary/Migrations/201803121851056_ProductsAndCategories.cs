namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsAndCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product_category",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        is_active = c.Boolean(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.category_id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        is_active = c.Boolean(nullable: false),
                        intial_stock = c.Int(nullable: false),
                        current_stock = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.product_category", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "category_id", "dbo.product_category");
            DropIndex("dbo.products", new[] { "category_id" });
            DropTable("dbo.products");
            DropTable("dbo.product_category");
        }
    }
}

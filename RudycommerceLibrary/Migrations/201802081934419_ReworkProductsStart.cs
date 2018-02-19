namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReworkProductsStart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.localized_product", "language_id", "dbo.language");
            DropForeignKey("dbo.localized_product", "product_id", "dbo.product");
            DropIndex("dbo.localized_product", new[] { "product_id" });
            DropIndex("dbo.localized_product", new[] { "language_id" });
            DropTable("dbo.localized_product");
            DropTable("dbo.product");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.product",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        is_active = c.Boolean(nullable: false),
                        initial_stock = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.localized_product",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.product_id, t.language_id });
            
            CreateIndex("dbo.localized_product", "language_id");
            CreateIndex("dbo.localized_product", "product_id");
            AddForeignKey("dbo.localized_product", "product_id", "dbo.product", "product_id", cascadeDelete: true);
            AddForeignKey("dbo.localized_product", "language_id", "dbo.language", "language_id", cascadeDelete: true);
        }
    }
}

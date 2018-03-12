namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProductProductProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product__product_properties",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        product_property_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.product_id, t.product_property_id })
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.product_properties", t => t.product_property_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.product_property_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.product__product_properties", "product_property_id", "dbo.product_properties");
            DropForeignKey("dbo.product__product_properties", "product_id", "dbo.products");
            DropIndex("dbo.product__product_properties", new[] { "product_property_id" });
            DropIndex("dbo.product__product_properties", new[] { "product_id" });
            DropTable("dbo.product__product_properties");
        }
    }
}

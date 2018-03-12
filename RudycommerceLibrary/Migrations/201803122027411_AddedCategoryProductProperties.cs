namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryProductProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.category__product_properties",
                c => new
                    {
                        product_property_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.product_property_id, t.category_id })
                .ForeignKey("dbo.product_category", t => t.category_id, cascadeDelete: true)
                .ForeignKey("dbo.product_properties", t => t.product_property_id, cascadeDelete: true)
                .Index(t => t.product_property_id)
                .Index(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.category__product_properties", "product_property_id", "dbo.product_properties");
            DropForeignKey("dbo.category__product_properties", "category_id", "dbo.product_category");
            DropIndex("dbo.category__product_properties", new[] { "category_id" });
            DropIndex("dbo.category__product_properties", new[] { "product_property_id" });
            DropTable("dbo.category__product_properties");
        }
    }
}

namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.language",
                c => new
                    {
                        language_id = c.Int(nullable: false, identity: true),
                        language_name = c.String(),
                        ISO = c.String(),
                        is_active = c.Boolean(nullable: false),
                        is_default = c.Boolean(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.language_id);
            
            CreateTable(
                "dbo.localized_product",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => new { t.product_id, t.language_id })
                .ForeignKey("dbo.language", t => t.language_id, cascadeDelete: true)
                .ForeignKey("dbo.product", t => t.product_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.language_id);
            
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
            DropForeignKey("dbo.localized_product", "product_id", "dbo.product");
            DropForeignKey("dbo.localized_product", "language_id", "dbo.language");
            DropIndex("dbo.localized_product", new[] { "language_id" });
            DropIndex("dbo.localized_product", new[] { "product_id" });
            DropTable("dbo.product");
            DropTable("dbo.localized_product");
            DropTable("dbo.language");
            DropTable("dbo.desktop_users");
        }
    }
}

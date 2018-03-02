namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocalKeyboard : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.gaming_keyboard",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        function_keys = c.Int(nullable: false),
                        layout = c.String(),
                        length = c.Single(nullable: false),
                        depth = c.Single(nullable: false),
                        width = c.Single(nullable: false),
                        weight = c.Single(nullable: false),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        is_active = c.Boolean(nullable: false),
                        initial_stock = c.Int(nullable: false),
                        current_stock = c.Int(nullable: false),
                        available_stock = c.Int(nullable: false),
                        iron_stock = c.Int(nullable: false),
                        maximum_stock = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.localized_gaming_keyboard",
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
                .PrimaryKey(t => new { t.product_id, t.language_id })
                .ForeignKey("dbo.gaming_keyboard", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.language", t => t.language_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.language_id);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.localized_headset", "language_id", "dbo.language");
            DropForeignKey("dbo.localized_gaming_keyboard", "language_id", "dbo.language");
            DropForeignKey("dbo.localized_gaming_controller", "language_id", "dbo.language");
            DropForeignKey("dbo.localized_gaming_keyboard", "product_id", "dbo.gaming_keyboard");
            DropForeignKey("dbo.localized_headset", "product_id", "dbo.headset");
            DropForeignKey("dbo.localized_gaming_controller", "product_id", "dbo.gaming_controller");
            DropIndex("dbo.localized_gaming_keyboard", new[] { "language_id" });
            DropIndex("dbo.localized_gaming_keyboard", new[] { "product_id" });
            DropIndex("dbo.localized_headset", new[] { "language_id" });
            DropIndex("dbo.localized_headset", new[] { "product_id" });
            DropIndex("dbo.localized_gaming_controller", new[] { "language_id" });
            DropIndex("dbo.localized_gaming_controller", new[] { "product_id" });
            
            DropTable("dbo.localized_gaming_keyboard");
            DropTable("dbo.gaming_keyboard");
            
        }
    }
}

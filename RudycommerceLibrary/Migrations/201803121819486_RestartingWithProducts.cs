namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestartingWithProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.localized_gaming_controller", "product_id", "dbo.gaming_controller");
            DropForeignKey("dbo.localized_headset", "product_id", "dbo.headset");
            DropForeignKey("dbo.localized_gaming_keyboard", "product_id", "dbo.gaming_keyboard");
            DropForeignKey("dbo.localized_gaming_controller", "language_id", "dbo.language");
            DropForeignKey("dbo.localized_gaming_keyboard", "language_id", "dbo.language");
            DropForeignKey("dbo.localized_headset", "language_id", "dbo.language");
            DropIndex("dbo.localized_gaming_controller", new[] { "product_id" });
            DropIndex("dbo.localized_gaming_controller", new[] { "language_id" });
            DropIndex("dbo.localized_headset", new[] { "product_id" });
            DropIndex("dbo.localized_headset", new[] { "language_id" });
            DropIndex("dbo.localized_gaming_keyboard", new[] { "product_id" });
            DropIndex("dbo.localized_gaming_keyboard", new[] { "language_id" });
            DropTable("dbo.gaming_controller");
            DropTable("dbo.localized_gaming_controller");
            DropTable("dbo.headset");
            DropTable("dbo.localized_headset");
            DropTable("dbo.gaming_keyboard");
            DropTable("dbo.localized_gaming_keyboard");
            DropTable("dbo.gaming_mouse");
            DropTable("dbo.mouse_mat");
            DropTable("dbo.product");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.product",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        type_of_product = c.String(),
                        type_of_equipment = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.mouse_mat",
                c => new
                    {
                        product_id = c.Int(nullable: false),
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
                "dbo.gaming_mouse",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        max_resolution = c.Int(nullable: false),
                        height = c.Single(nullable: false),
                        length = c.Single(nullable: false),
                        width = c.Single(nullable: false),
                        programmable_buttons = c.Int(nullable: false),
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
                .PrimaryKey(t => new { t.product_id, t.language_id });
            
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
                "dbo.localized_headset",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        wearing_way = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.product_id, t.language_id });
            
            CreateTable(
                "dbo.headset",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        integrated_microphone = c.Boolean(nullable: false),
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
                "dbo.localized_gaming_controller",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        position_dpad = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.product_id, t.language_id });
            
            CreateTable(
                "dbo.gaming_controller",
                c => new
                    {
                        product_id = c.Int(nullable: false),
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
            
            CreateIndex("dbo.localized_gaming_keyboard", "language_id");
            CreateIndex("dbo.localized_gaming_keyboard", "product_id");
            CreateIndex("dbo.localized_headset", "language_id");
            CreateIndex("dbo.localized_headset", "product_id");
            CreateIndex("dbo.localized_gaming_controller", "language_id");
            CreateIndex("dbo.localized_gaming_controller", "product_id");
            AddForeignKey("dbo.localized_headset", "language_id", "dbo.language", "language_id", cascadeDelete: true);
            AddForeignKey("dbo.localized_gaming_keyboard", "language_id", "dbo.language", "language_id", cascadeDelete: true);
            AddForeignKey("dbo.localized_gaming_controller", "language_id", "dbo.language", "language_id", cascadeDelete: true);
            AddForeignKey("dbo.localized_gaming_keyboard", "product_id", "dbo.gaming_keyboard", "product_id", cascadeDelete: true);
            AddForeignKey("dbo.localized_headset", "product_id", "dbo.headset", "product_id", cascadeDelete: true);
            AddForeignKey("dbo.localized_gaming_controller", "product_id", "dbo.gaming_controller", "product_id", cascadeDelete: true);
        }
    }
}

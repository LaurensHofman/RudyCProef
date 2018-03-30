namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartOnAsus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.articles",
                c => new
                    {
                        article_id = c.Int(nullable: false, identity: true),
                        serial_number = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.article_id)
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .Index(t => t.product_id);
            
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
            
            CreateTable(
                "dbo.localized__product__specific_product_properties",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        specific_product_property_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        property_value = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.product_id, t.specific_product_property_id, t.language_id })
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.languages", t => t.language_id, cascadeDelete: true)
                .ForeignKey("dbo.specific_product_properties", t => t.specific_product_property_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.specific_product_property_id)
                .Index(t => t.language_id);
            
            CreateTable(
                "dbo.localized_products",
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
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.languages", t => t.language_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.language_id);
            
            CreateTable(
                "dbo.product__specific_product_properties",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        specific_product_property_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.product_id, t.specific_product_property_id })
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.specific_product_properties", t => t.specific_product_property_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.specific_product_property_id);
            
            CreateTable(
                "dbo.product_category",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        parent_id = c.Int(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.category_id)
                .ForeignKey("dbo.product_category", t => t.parent_id)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.category__specific_product_properties",
                c => new
                    {
                        specific_product_property_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.specific_product_property_id, t.category_id })
                .ForeignKey("dbo.product_category", t => t.category_id, cascadeDelete: true)
                .ForeignKey("dbo.specific_product_properties", t => t.specific_product_property_id, cascadeDelete: true)
                .Index(t => t.specific_product_property_id)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.localized_product_category",
                c => new
                    {
                        category_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        name = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.category_id, t.language_id })
                .ForeignKey("dbo.product_category", t => t.category_id, cascadeDelete: true)
                .ForeignKey("dbo.languages", t => t.language_id, cascadeDelete: true)
                .Index(t => t.category_id)
                .Index(t => t.language_id);
            
            CreateTable(
                "dbo.desktop_users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        is_admin = c.Boolean(nullable: false),
                        verified_by_admin = c.Boolean(nullable: false),
                        last_name = c.String(),
                        first_name = c.String(),
                        email = c.String(),
                        preferred_language_id = c.Int(nullable: false),
                        username = c.String(),
                        encrypted_password = c.String(),
                        salt = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("dbo.languages", t => t.preferred_language_id, cascadeDelete: true)
                .Index(t => t.preferred_language_id);
            
            CreateTable(
                "dbo.languages",
                c => new
                    {
                        language_id = c.Int(nullable: false, identity: true),
                        local_name = c.String(nullable: false, maxLength: 255),
                        dutch_name = c.String(nullable: false, maxLength: 255),
                        english_name = c.String(nullable: false, maxLength: 255),
                        ISO = c.String(nullable: false, maxLength: 3),
                        is_desktop_language = c.Boolean(nullable: false),
                        is_active = c.Boolean(nullable: false),
                        is_default = c.Boolean(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.language_id)
                .Index(t => t.ISO, unique: true);
            
            CreateTable(
                "dbo.specific_product_properties_localized",
                c => new
                    {
                        specific_product_property_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        lookup_name = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.specific_product_property_id, t.language_id })
                .ForeignKey("dbo.languages", t => t.language_id, cascadeDelete: true)
                .ForeignKey("dbo.specific_product_properties", t => t.specific_product_property_id, cascadeDelete: true)
                .Index(t => t.specific_product_property_id)
                .Index(t => t.language_id);
            
            CreateTable(
                "dbo.specific_product_properties",
                c => new
                    {
                        specific_product_property_id = c.Int(nullable: false, identity: true),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.specific_product_property_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.product__specific_product_properties", "specific_product_property_id", "dbo.specific_product_properties");
            DropForeignKey("dbo.specific_product_properties_localized", "specific_product_property_id", "dbo.specific_product_properties");
            DropForeignKey("dbo.localized__product__specific_product_properties", "specific_product_property_id", "dbo.specific_product_properties");
            DropForeignKey("dbo.category__specific_product_properties", "specific_product_property_id", "dbo.specific_product_properties");
            DropForeignKey("dbo.desktop_users", "preferred_language_id", "dbo.languages");
            DropForeignKey("dbo.specific_product_properties_localized", "language_id", "dbo.languages");
            DropForeignKey("dbo.localized_products", "language_id", "dbo.languages");
            DropForeignKey("dbo.localized_product_category", "language_id", "dbo.languages");
            DropForeignKey("dbo.localized__product__specific_product_properties", "language_id", "dbo.languages");
            DropForeignKey("dbo.articles", "product_id", "dbo.products");
            DropForeignKey("dbo.products", "category_id", "dbo.product_category");
            DropForeignKey("dbo.product_category", "parent_id", "dbo.product_category");
            DropForeignKey("dbo.localized_product_category", "category_id", "dbo.product_category");
            DropForeignKey("dbo.category__specific_product_properties", "category_id", "dbo.product_category");
            DropForeignKey("dbo.product__specific_product_properties", "product_id", "dbo.products");
            DropForeignKey("dbo.localized_products", "product_id", "dbo.products");
            DropForeignKey("dbo.localized__product__specific_product_properties", "product_id", "dbo.products");
            DropIndex("dbo.specific_product_properties_localized", new[] { "language_id" });
            DropIndex("dbo.specific_product_properties_localized", new[] { "specific_product_property_id" });
            DropIndex("dbo.languages", new[] { "ISO" });
            DropIndex("dbo.desktop_users", new[] { "preferred_language_id" });
            DropIndex("dbo.localized_product_category", new[] { "language_id" });
            DropIndex("dbo.localized_product_category", new[] { "category_id" });
            DropIndex("dbo.category__specific_product_properties", new[] { "category_id" });
            DropIndex("dbo.category__specific_product_properties", new[] { "specific_product_property_id" });
            DropIndex("dbo.product_category", new[] { "parent_id" });
            DropIndex("dbo.product__specific_product_properties", new[] { "specific_product_property_id" });
            DropIndex("dbo.product__specific_product_properties", new[] { "product_id" });
            DropIndex("dbo.localized_products", new[] { "language_id" });
            DropIndex("dbo.localized_products", new[] { "product_id" });
            DropIndex("dbo.localized__product__specific_product_properties", new[] { "language_id" });
            DropIndex("dbo.localized__product__specific_product_properties", new[] { "specific_product_property_id" });
            DropIndex("dbo.localized__product__specific_product_properties", new[] { "product_id" });
            DropIndex("dbo.products", new[] { "category_id" });
            DropIndex("dbo.articles", new[] { "product_id" });
            DropTable("dbo.specific_product_properties");
            DropTable("dbo.specific_product_properties_localized");
            DropTable("dbo.languages");
            DropTable("dbo.desktop_users");
            DropTable("dbo.localized_product_category");
            DropTable("dbo.category__specific_product_properties");
            DropTable("dbo.product_category");
            DropTable("dbo.product__specific_product_properties");
            DropTable("dbo.localized_products");
            DropTable("dbo.localized__product__specific_product_properties");
            DropTable("dbo.products");
            DropTable("dbo.articles");
        }
    }
}

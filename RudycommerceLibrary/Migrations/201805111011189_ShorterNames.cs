namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShorterNames : DbMigration
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
                        unit_price = c.Decimal(precision: 18, scale: 2),
                        is_active = c.Boolean(nullable: false),
                        intial_stock = c.Int(),
                        current_stock = c.Int(),
                        category_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.product_category", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.product_images",
                c => new
                    {
                        image_id = c.Int(nullable: false, identity: true),
                        product_id = c.Int(nullable: false),
                        order = c.Int(nullable: false),
                        image_url = c.String(),
                    })
                .PrimaryKey(t => t.image_id)
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.localized_products",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => new { t.product_id, t.language_id })
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.languages", t => t.language_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.language_id);
            
            CreateTable(
                "dbo.product__product_properties",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        specific_product_property_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.product_id, t.specific_product_property_id })
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.product_properties", t => t.specific_product_property_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.specific_product_property_id);
            
            CreateTable(
                "dbo.product_category",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.category_id);
            
            CreateTable(
                "dbo.category_properties",
                c => new
                    {
                        property_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.property_id, t.category_id })
                .ForeignKey("dbo.product_category", t => t.category_id, cascadeDelete: true)
                .ForeignKey("dbo.product_properties", t => t.property_id, cascadeDelete: true)
                .Index(t => t.property_id)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.localized_category",
                c => new
                    {
                        category_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => new { t.category_id, t.language_id })
                .ForeignKey("dbo.product_category", t => t.category_id, cascadeDelete: true)
                .ForeignKey("dbo.languages", t => t.language_id, cascadeDelete: true)
                .Index(t => t.category_id)
                .Index(t => t.language_id);
            
            CreateTable(
                "dbo.values__product__product_properties",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        specific_product_property_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        input_value = c.String(),
                        enumeration_value_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.product_id, t.specific_product_property_id, t.language_id })
                .ForeignKey("dbo.product_properties", t => t.specific_product_property_id, cascadeDelete: true)
                .ForeignKey("dbo.property_enumerations", t => t.enumeration_value_id)
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.languages", t => t.language_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.specific_product_property_id)
                .Index(t => t.language_id)
                .Index(t => t.enumeration_value_id);
            
            CreateTable(
                "dbo.property_enumerations",
                c => new
                    {
                        enumeration_id = c.Int(nullable: false, identity: true),
                        specific_property_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.enumeration_id)
                .ForeignKey("dbo.product_properties", t => t.specific_property_id, cascadeDelete: true)
                .Index(t => t.specific_property_id);
            
            CreateTable(
                "dbo.localized_enumeration_values",
                c => new
                    {
                        enumeration_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        value = c.String(),
                    })
                .PrimaryKey(t => new { t.enumeration_id, t.language_id })
                .ForeignKey("dbo.property_enumerations", t => t.enumeration_id, cascadeDelete: true)
                .ForeignKey("dbo.languages", t => t.language_id, cascadeDelete: true)
                .Index(t => t.enumeration_id)
                .Index(t => t.language_id);
            
            CreateTable(
                "dbo.product_properties",
                c => new
                    {
                        property_id = c.Int(nullable: false, identity: true),
                        is_multilingual = c.Boolean(nullable: false),
                        is_bool = c.Boolean(nullable: false),
                        is_enumeration = c.Boolean(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.property_id);
            
            CreateTable(
                "dbo.localized_property",
                c => new
                    {
                        property_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        lookup_name = c.String(),
                    })
                .PrimaryKey(t => new { t.property_id, t.language_id })
                .ForeignKey("dbo.product_properties", t => t.property_id, cascadeDelete: true)
                .ForeignKey("dbo.languages", t => t.language_id, cascadeDelete: true)
                .Index(t => t.property_id)
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
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.desktop_users", "preferred_language_id", "dbo.languages");
            DropForeignKey("dbo.localized_property", "language_id", "dbo.languages");
            DropForeignKey("dbo.localized_products", "language_id", "dbo.languages");
            DropForeignKey("dbo.localized_category", "language_id", "dbo.languages");
            DropForeignKey("dbo.localized_enumeration_values", "language_id", "dbo.languages");
            DropForeignKey("dbo.values__product__product_properties", "language_id", "dbo.languages");
            DropForeignKey("dbo.articles", "product_id", "dbo.products");
            DropForeignKey("dbo.values__product__product_properties", "product_id", "dbo.products");
            DropForeignKey("dbo.values__product__product_properties", "enumeration_value_id", "dbo.property_enumerations");
            DropForeignKey("dbo.property_enumerations", "specific_property_id", "dbo.product_properties");
            DropForeignKey("dbo.product__product_properties", "specific_product_property_id", "dbo.product_properties");
            DropForeignKey("dbo.localized_property", "property_id", "dbo.product_properties");
            DropForeignKey("dbo.values__product__product_properties", "specific_product_property_id", "dbo.product_properties");
            DropForeignKey("dbo.category_properties", "property_id", "dbo.product_properties");
            DropForeignKey("dbo.localized_enumeration_values", "enumeration_id", "dbo.property_enumerations");
            DropForeignKey("dbo.products", "category_id", "dbo.product_category");
            DropForeignKey("dbo.localized_category", "category_id", "dbo.product_category");
            DropForeignKey("dbo.category_properties", "category_id", "dbo.product_category");
            DropForeignKey("dbo.product__product_properties", "product_id", "dbo.products");
            DropForeignKey("dbo.localized_products", "product_id", "dbo.products");
            DropForeignKey("dbo.product_images", "product_id", "dbo.products");
            DropIndex("dbo.languages", new[] { "ISO" });
            DropIndex("dbo.desktop_users", new[] { "preferred_language_id" });
            DropIndex("dbo.localized_property", new[] { "language_id" });
            DropIndex("dbo.localized_property", new[] { "property_id" });
            DropIndex("dbo.localized_enumeration_values", new[] { "language_id" });
            DropIndex("dbo.localized_enumeration_values", new[] { "enumeration_id" });
            DropIndex("dbo.property_enumerations", new[] { "specific_property_id" });
            DropIndex("dbo.values__product__product_properties", new[] { "enumeration_value_id" });
            DropIndex("dbo.values__product__product_properties", new[] { "language_id" });
            DropIndex("dbo.values__product__product_properties", new[] { "specific_product_property_id" });
            DropIndex("dbo.values__product__product_properties", new[] { "product_id" });
            DropIndex("dbo.localized_category", new[] { "language_id" });
            DropIndex("dbo.localized_category", new[] { "category_id" });
            DropIndex("dbo.category_properties", new[] { "category_id" });
            DropIndex("dbo.category_properties", new[] { "property_id" });
            DropIndex("dbo.product__product_properties", new[] { "specific_product_property_id" });
            DropIndex("dbo.product__product_properties", new[] { "product_id" });
            DropIndex("dbo.localized_products", new[] { "language_id" });
            DropIndex("dbo.localized_products", new[] { "product_id" });
            DropIndex("dbo.product_images", new[] { "product_id" });
            DropIndex("dbo.products", new[] { "category_id" });
            DropIndex("dbo.articles", new[] { "product_id" });
            DropTable("dbo.languages");
            DropTable("dbo.desktop_users");
            DropTable("dbo.localized_property");
            DropTable("dbo.product_properties");
            DropTable("dbo.localized_enumeration_values");
            DropTable("dbo.property_enumerations");
            DropTable("dbo.values__product__product_properties");
            DropTable("dbo.localized_category");
            DropTable("dbo.category_properties");
            DropTable("dbo.product_category");
            DropTable("dbo.product__product_properties");
            DropTable("dbo.localized_products");
            DropTable("dbo.product_images");
            DropTable("dbo.products");
            DropTable("dbo.articles");
        }
    }
}

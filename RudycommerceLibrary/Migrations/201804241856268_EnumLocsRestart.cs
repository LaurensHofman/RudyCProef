namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumLocsRestart : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.values__product__specific_product_properties",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        specific_product_property_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        input_value = c.String(),
                        enumeration_value_id = c.Int(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.product_id, t.specific_product_property_id, t.language_id })
                .ForeignKey("dbo.specific_product_properties", t => t.specific_product_property_id, cascadeDelete: true)
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
                .ForeignKey("dbo.specific_product_properties", t => t.specific_property_id, cascadeDelete: true)
                .Index(t => t.specific_property_id);
            
            CreateTable(
                "dbo.localized_enumeration_values",
                c => new
                    {
                        localized_value_enum_id = c.Int(nullable: false, identity: true),
                        value = c.String(),
                        enumeration_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.localized_value_enum_id)
                .ForeignKey("dbo.property_enumerations", t => t.enumeration_id, cascadeDelete: true)
                .Index(t => t.enumeration_id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.values__product__specific_product_properties", "language_id", "dbo.languages");
            DropForeignKey("dbo.values__product__specific_product_properties", "product_id", "dbo.products");
            DropForeignKey("dbo.values__product__specific_product_properties", "enumeration_value_id", "dbo.property_enumerations");
            DropForeignKey("dbo.property_enumerations", "specific_property_id", "dbo.specific_product_properties");
            DropForeignKey("dbo.values__product__specific_product_properties", "specific_product_property_id", "dbo.specific_product_properties");
            DropForeignKey("dbo.localized_enumeration_values", "enumeration_id", "dbo.property_enumerations");
            DropIndex("dbo.localized_enumeration_values", new[] { "enumeration_id" });
            DropIndex("dbo.property_enumerations", new[] { "specific_property_id" });
            DropIndex("dbo.values__product__specific_product_properties", new[] { "enumeration_value_id" });
            DropIndex("dbo.values__product__specific_product_properties", new[] { "language_id" });
            DropIndex("dbo.values__product__specific_product_properties", new[] { "specific_product_property_id" });
            DropIndex("dbo.values__product__specific_product_properties", new[] { "product_id" });
            DropTable("dbo.localized_enumeration_values");
            DropTable("dbo.property_enumerations");
            DropTable("dbo.values__product__specific_product_properties");
        }
    }
}

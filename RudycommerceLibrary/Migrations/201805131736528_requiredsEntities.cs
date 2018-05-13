namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredsEntities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "unit_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.products", "intial_stock", c => c.Int(nullable: false));
            AlterColumn("dbo.products", "current_stock", c => c.Int(nullable: false));
            AlterColumn("dbo.product_images", "image_url", c => c.String(nullable: false));
            AlterColumn("dbo.localized_products", "name", c => c.String(nullable: false));
            AlterColumn("dbo.localized_products", "description", c => c.String(nullable: false));
            AlterColumn("dbo.localized_category", "name", c => c.String(nullable: false));
            AlterColumn("dbo.localized_enumeration_values", "value", c => c.String(nullable: false));
            AlterColumn("dbo.localized_property", "lookup_name", c => c.String(nullable: false));
            AlterColumn("dbo.desktop_users", "last_name", c => c.String(nullable: false));
            AlterColumn("dbo.desktop_users", "first_name", c => c.String(nullable: false));
            AlterColumn("dbo.desktop_users", "email", c => c.String(nullable: false));
            AlterColumn("dbo.desktop_users", "username", c => c.String(nullable: false));
            AlterColumn("dbo.desktop_users", "encrypted_password", c => c.String(nullable: false));
            AlterColumn("dbo.desktop_users", "salt", c => c.String(nullable: false));
            AlterColumn("dbo.languages", "flag_icon_url", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.languages", "flag_icon_url", c => c.String());
            AlterColumn("dbo.desktop_users", "salt", c => c.String());
            AlterColumn("dbo.desktop_users", "encrypted_password", c => c.String());
            AlterColumn("dbo.desktop_users", "username", c => c.String());
            AlterColumn("dbo.desktop_users", "email", c => c.String());
            AlterColumn("dbo.desktop_users", "first_name", c => c.String());
            AlterColumn("dbo.desktop_users", "last_name", c => c.String());
            AlterColumn("dbo.localized_property", "lookup_name", c => c.String());
            AlterColumn("dbo.localized_enumeration_values", "value", c => c.String());
            AlterColumn("dbo.localized_category", "name", c => c.String());
            AlterColumn("dbo.localized_products", "description", c => c.String());
            AlterColumn("dbo.localized_products", "name", c => c.String());
            AlterColumn("dbo.product_images", "image_url", c => c.String());
            AlterColumn("dbo.products", "current_stock", c => c.Int());
            AlterColumn("dbo.products", "intial_stock", c => c.Int());
            AlterColumn("dbo.products", "unit_price", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}

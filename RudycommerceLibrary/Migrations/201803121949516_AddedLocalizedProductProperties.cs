namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocalizedProductProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product_properties_localized",
                c => new
                    {
                        product_property_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        lookup_name = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.product_property_id, t.language_id })
                .ForeignKey("dbo.language", t => t.language_id, cascadeDelete: true)
                .ForeignKey("dbo.product_properties", t => t.product_property_id, cascadeDelete: true)
                .Index(t => t.product_property_id)
                .Index(t => t.language_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.product_properties_localized", "product_property_id", "dbo.product_properties");
            DropForeignKey("dbo.product_properties_localized", "language_id", "dbo.language");
            DropIndex("dbo.product_properties_localized", new[] { "language_id" });
            DropIndex("dbo.product_properties_localized", new[] { "product_property_id" });
            DropTable("dbo.product_properties_localized");
        }
    }
}

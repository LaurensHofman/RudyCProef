namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryAndParents1 : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.language", t => t.language_id, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.language_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.localized_products", "product_id", "dbo.products");
            DropForeignKey("dbo.localized_products", "language_id", "dbo.language");
            DropIndex("dbo.localized_products", new[] { "language_id" });
            DropIndex("dbo.localized_products", new[] { "product_id" });
            DropTable("dbo.localized_products");
        }
    }
}

namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocalizedProductCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.localized_product_category",
                c => new
                    {
                        category_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => new { t.category_id, t.language_id })
                .ForeignKey("dbo.language", t => t.language_id, cascadeDelete: true)
                .ForeignKey("dbo.product_category", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id)
                .Index(t => t.language_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.localized_product_category", "category_id", "dbo.product_category");
            DropForeignKey("dbo.localized_product_category", "language_id", "dbo.language");
            DropIndex("dbo.localized_product_category", new[] { "language_id" });
            DropIndex("dbo.localized_product_category", new[] { "category_id" });
            DropTable("dbo.localized_product_category");
        }
    }
}

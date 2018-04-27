namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product_images",
                c => new
                    {
                        image_id = c.Int(nullable: false, identity: true),
                        product_id = c.Int(nullable: false),
                        image_url = c.String(),
                    })
                .PrimaryKey(t => t.image_id)
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .Index(t => t.product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.product_images", "product_id", "dbo.products");
            DropIndex("dbo.product_images", new[] { "product_id" });
            DropTable("dbo.product_images");
        }
    }
}

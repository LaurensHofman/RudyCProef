namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryAndParents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product_category", "parent_id", c => c.Int());
            CreateIndex("dbo.product_category", "parent_id");
            AddForeignKey("dbo.product_category", "parent_id", "dbo.product_category", "category_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.product_category", "parent_id", "dbo.product_category");
            DropIndex("dbo.product_category", new[] { "parent_id" });
            DropColumn("dbo.product_category", "parent_id");
        }
    }
}

namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product_images", "order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.product_images", "order");
        }
    }
}

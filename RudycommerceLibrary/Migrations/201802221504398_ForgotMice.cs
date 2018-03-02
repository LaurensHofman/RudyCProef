namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForgotMice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.mouse",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        max_resolution = c.Int(nullable: false),
                        height = c.Single(nullable: false),
                        length = c.Single(nullable: false),
                        width = c.Single(nullable: false),
                        programmable_buttons = c.Int(nullable: false),
                        weight = c.Single(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.mouse");
        }
    }
}

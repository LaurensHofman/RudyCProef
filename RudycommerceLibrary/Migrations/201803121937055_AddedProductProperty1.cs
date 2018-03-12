namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductProperty1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product_properties",
                c => new
                    {
                        product_property_id = c.Int(nullable: false, identity: true),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_property_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.product_properties");
        }
    }
}

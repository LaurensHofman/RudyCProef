namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vPropertyWithName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.vPropertyWithName",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        is_multilingual = c.Boolean(nullable: false),
                        is_bool = c.Boolean(nullable: false),
                        specific_product_property_id = c.Int(nullable: false),
                        lookup_name = c.String(),
                        language_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.testView");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.testView",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        lookup_name = c.String(),
                        is_bool = c.Boolean(nullable: false),
                        is_multilingual = c.Boolean(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyID);
            
            DropTable("dbo.vPropertyWithName");
        }
    }
}

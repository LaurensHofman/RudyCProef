namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testView : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.testView");
        }
    }
}

namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecProdPropIsML : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.specific_product_properties", "is_multilingual", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.specific_product_properties", "is_multilingual");
        }
    }
}

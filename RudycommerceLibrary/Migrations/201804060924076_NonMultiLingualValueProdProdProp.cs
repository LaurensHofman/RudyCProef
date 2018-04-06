namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NonMultiLingualValueProdProdProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product__specific_product_properties", "non_multilingual_value", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.product__specific_product_properties", "non_multilingual_value");
        }
    }
}

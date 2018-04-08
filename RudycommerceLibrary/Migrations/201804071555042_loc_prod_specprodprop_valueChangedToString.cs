namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loc_prod_specprodprop_valueChangedToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.localized__product__specific_product_properties", "property_value", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.localized__product__specific_product_properties", "property_value", c => c.Int(nullable: false));
        }
    }
}

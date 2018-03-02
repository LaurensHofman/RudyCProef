namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Equipments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.controller",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        weight = c.Single(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.headset",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        weight = c.Single(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.keyboard",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        function_keys = c.Int(nullable: false),
                        layout = c.String(),
                        length = c.Int(nullable: false),
                        depth = c.Int(nullable: false),
                        width = c.Int(nullable: false),
                        weight = c.Single(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.mouse_mat",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        length = c.Int(nullable: false),
                        depth = c.Int(nullable: false),
                        width = c.Int(nullable: false),
                        weight = c.Single(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.mouse_mat");
            DropTable("dbo.keyboard");
            DropTable("dbo.headset");
            DropTable("dbo.controller");
        }
    }
}

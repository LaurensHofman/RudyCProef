namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Equipments1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.keyboard", "length", c => c.Single(nullable: false));
            AlterColumn("dbo.keyboard", "depth", c => c.Single(nullable: false));
            AlterColumn("dbo.keyboard", "width", c => c.Single(nullable: false));
            AlterColumn("dbo.mouse_mat", "length", c => c.Single(nullable: false));
            AlterColumn("dbo.mouse_mat", "depth", c => c.Single(nullable: false));
            AlterColumn("dbo.mouse_mat", "width", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.mouse_mat", "width", c => c.Int(nullable: false));
            AlterColumn("dbo.mouse_mat", "depth", c => c.Int(nullable: false));
            AlterColumn("dbo.mouse_mat", "length", c => c.Int(nullable: false));
            AlterColumn("dbo.keyboard", "width", c => c.Int(nullable: false));
            AlterColumn("dbo.keyboard", "depth", c => c.Int(nullable: false));
            AlterColumn("dbo.keyboard", "length", c => c.Int(nullable: false));
        }
    }
}

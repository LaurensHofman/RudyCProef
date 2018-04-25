namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumLocsretry : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.localized_enumeration_values");
            AddColumn("dbo.localized_enumeration_values", "language_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.localized_enumeration_values", new[] { "enumeration_id", "language_id" });
            CreateIndex("dbo.localized_enumeration_values", "language_id");
            AddForeignKey("dbo.localized_enumeration_values", "language_id", "dbo.languages", "language_id", cascadeDelete: true);
            DropColumn("dbo.localized_enumeration_values", "localized_value_enum_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.localized_enumeration_values", "localized_value_enum_id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.localized_enumeration_values", "language_id", "dbo.languages");
            DropIndex("dbo.localized_enumeration_values", new[] { "language_id" });
            DropPrimaryKey("dbo.localized_enumeration_values");
            DropColumn("dbo.localized_enumeration_values", "language_id");
            AddPrimaryKey("dbo.localized_enumeration_values", "localized_value_enum_id");
        }
    }
}

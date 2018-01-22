namespace RudycommerceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesktopUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.desktop_users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        is_admin = c.Boolean(nullable: false),
                        last_name = c.String(),
                        first_name = c.String(),
                        email = c.String(),
                        pref_language = c.String(),
                        username = c.String(),
                        encrypted_password = c.String(),
                        salt = c.String(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.user_id);
         }
        
        public override void Down()
        {
            DropTable("dbo.desktop_users");
        }
    }
}

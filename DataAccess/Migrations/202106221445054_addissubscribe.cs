namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addissubscribe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribe");
        }
    }
}

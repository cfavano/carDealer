namespace CarsStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Models", "UserID", c => c.String());
            AlterColumn("dbo.Makes", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Makes", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Models", "UserID", c => c.Int(nullable: false));
        }
    }
}

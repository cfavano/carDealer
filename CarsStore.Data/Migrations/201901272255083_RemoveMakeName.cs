namespace CarsStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMakeName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Models", "MakeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "MakeName", c => c.String());
        }
    }
}

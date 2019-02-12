namespace CarsStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIDs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "CarID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "CarID");
        }
    }
}

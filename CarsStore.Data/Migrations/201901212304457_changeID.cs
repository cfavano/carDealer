namespace CarsStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cars");
            AddColumn("dbo.Cars", "CarID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cars", "VinID", c => c.String());
            AddPrimaryKey("dbo.Cars", "CarID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Cars");
            AlterColumn("dbo.Cars", "VinID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Cars", "CarID");
            AddPrimaryKey("dbo.Cars", "VinID");
        }
    }
}

namespace CarsStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyStyles",
                c => new
                    {
                        BodyStyleID = c.Int(nullable: false, identity: true),
                        BodyStyleName = c.String(),
                    })
                .PrimaryKey(t => t.BodyStyleID);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        VinID = c.String(nullable: false, maxLength: 128),
                        IsFeatured = c.Boolean(nullable: false),
                        Picture = c.String(),
                        Year = c.Short(nullable: false),
                        ModelID = c.Int(nullable: false),
                        BodyStyleID = c.Int(nullable: false),
                        TransmissionID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        SalesPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        IsNew = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        InteriorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VinID)
                .ForeignKey("dbo.BodyStyles", t => t.BodyStyleID, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.Interiors", t => t.InteriorID, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelID, cascadeDelete: true)
                .ForeignKey("dbo.Transmissions", t => t.TransmissionID, cascadeDelete: true)
                .Index(t => t.ModelID)
                .Index(t => t.BodyStyleID)
                .Index(t => t.TransmissionID)
                .Index(t => t.ColorID)
                .Index(t => t.InteriorID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.Interiors",
                c => new
                    {
                        InteriorID = c.Int(nullable: false, identity: true),
                        InteriorColor = c.String(),
                    })
                .PrimaryKey(t => t.InteriorID);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        MakeID = c.Int(nullable: false),
                        MakeName = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelID)
                .ForeignKey("dbo.Makes", t => t.MakeID, cascadeDelete: true)
                .Index(t => t.MakeID);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        MakeID = c.Int(nullable: false, identity: true),
                        MakeName = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MakeID);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionID = c.Int(nullable: false, identity: true),
                        TransmissionType = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionID);
            
            CreateTable(
                "dbo.ContactMessages",
                c => new
                    {
                        ContactMessageID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactMessageID);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeID = c.Int(nullable: false, identity: true),
                        PurchaseTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        StateID = c.Int(nullable: false),
                        Zip = c.String(),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseTypeID = c.Int(nullable: false),
                        SalesPerson = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        VinID = c.String(),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeID, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateID, cascadeDelete: true)
                .Index(t => t.StateID)
                .Index(t => t.PurchaseTypeID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        StateAbbreviation = c.String(),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        SpecialsID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SpecialsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "StateID", "dbo.States");
            DropForeignKey("dbo.Sales", "PurchaseTypeID", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Cars", "TransmissionID", "dbo.Transmissions");
            DropForeignKey("dbo.Cars", "ModelID", "dbo.Models");
            DropForeignKey("dbo.Models", "MakeID", "dbo.Makes");
            DropForeignKey("dbo.Cars", "InteriorID", "dbo.Interiors");
            DropForeignKey("dbo.Cars", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Cars", "BodyStyleID", "dbo.BodyStyles");
            DropIndex("dbo.Sales", new[] { "PurchaseTypeID" });
            DropIndex("dbo.Sales", new[] { "StateID" });
            DropIndex("dbo.Models", new[] { "MakeID" });
            DropIndex("dbo.Cars", new[] { "InteriorID" });
            DropIndex("dbo.Cars", new[] { "ColorID" });
            DropIndex("dbo.Cars", new[] { "TransmissionID" });
            DropIndex("dbo.Cars", new[] { "BodyStyleID" });
            DropIndex("dbo.Cars", new[] { "ModelID" });
            DropTable("dbo.Specials");
            DropTable("dbo.States");
            DropTable("dbo.Sales");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.ContactMessages");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Makes");
            DropTable("dbo.Models");
            DropTable("dbo.Interiors");
            DropTable("dbo.Colors");
            DropTable("dbo.Cars");
            DropTable("dbo.BodyStyles");
        }
    }
}

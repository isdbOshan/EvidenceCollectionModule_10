namespace EquipmentPart_Mid_Month_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false, identity: true),
                        EquipmentName = c.String(nullable: false, maxLength: 50),
                        DeliveryDate = c.DateTime(nullable: false, storeType: "date"),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Available = c.Boolean(nullable: false),
                        Picture = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        PartName = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.PartDetails",
                c => new
                    {
                        PartDetailId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Expiredate = c.DateTime(nullable: false, storeType: "date"),
                        Material = c.String(nullable: false, maxLength: 50),
                        Company = c.String(nullable: false, maxLength: 50),
                        PartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartDetailId)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.PartId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.PartDetails", "PartId", "dbo.Parts");
            DropForeignKey("dbo.Parts", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.PartDetails", new[] { "PartId" });
            DropIndex("dbo.Parts", new[] { "EquipmentId" });
            DropIndex("dbo.Customers", new[] { "EquipmentId" });
            DropTable("dbo.PartDetails");
            DropTable("dbo.Parts");
            DropTable("dbo.Equipments");
            DropTable("dbo.Customers");
        }
    }
}

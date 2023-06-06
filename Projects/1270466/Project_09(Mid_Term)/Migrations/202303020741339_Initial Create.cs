namespace Project_09_Mid_Term_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        ComputerId = c.Int(nullable: false, identity: true),
                        ComputerName = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        MGFDate = c.DateTime(nullable: false, storeType: "date"),
                        Picture = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ComputerId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ComputerId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Computers", t => t.ComputerId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ComputerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false, storeType: "date"),
                        DelivaryDate = c.DateTime(nullable: false, storeType: "date"),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        phone = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderItems", "ComputerId", "dbo.Computers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderItems", new[] { "ComputerId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Computers");
        }
    }
}

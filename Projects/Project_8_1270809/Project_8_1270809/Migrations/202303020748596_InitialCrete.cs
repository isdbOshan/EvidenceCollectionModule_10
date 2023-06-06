namespace Project_8_1270809.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCrete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        ResutlId = c.Int(nullable: false, identity: true),
                        Result = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResutlId)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamId = c.Int(nullable: false, identity: true),
                        ExamName = c.String(nullable: false, maxLength: 50),
                        date = c.DateTime(nullable: false),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamId)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(nullable: false),
                        TimeDuration = c.Int(nullable: false),
                        TraineeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.Trainees", t => t.TraineeId, cascadeDelete: true)
                .Index(t => t.TraineeId);
            
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        TraineeId = c.Int(nullable: false, identity: true),
                        TraineeName = c.String(nullable: false, maxLength: 50),
                        money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        date = c.DateTime(nullable: false),
                        OnAddmited = c.Boolean(nullable: false),
                        Picture = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TraineeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamResults", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Modules", "TraineeId", "dbo.Trainees");
            DropForeignKey("dbo.Exams", "ModuleId", "dbo.Modules");
            DropIndex("dbo.Modules", new[] { "TraineeId" });
            DropIndex("dbo.Exams", new[] { "ModuleId" });
            DropIndex("dbo.ExamResults", new[] { "ExamId" });
            DropTable("dbo.Trainees");
            DropTable("dbo.Modules");
            DropTable("dbo.Exams");
            DropTable("dbo.ExamResults");
        }
    }
}

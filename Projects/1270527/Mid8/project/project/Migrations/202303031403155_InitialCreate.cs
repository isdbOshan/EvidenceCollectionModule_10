namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Locations = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AreaId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 50),
                        StudentPhone = c.String(nullable: false, maxLength: 50),
                        StudentEmail = c.String(nullable: false, maxLength: 50),
                        Studentdob = c.DateTime(nullable: false, storeType: "date"),
                        StudentClass = c.String(nullable: false, maxLength: 50),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false, maxLength: 50),
                        ExpectedAmount = c.Decimal(nullable: false, storeType: "money"),
                        Teacherdob = c.DateTime(nullable: false, storeType: "date"),
                        TeacherPhone = c.String(nullable: false, maxLength: 50),
                        TeacherEmail = c.String(nullable: false, maxLength: 50),
                        IsAvailable = c.Boolean(nullable: false),
                        Picture = c.String(nullable: false, maxLength: 50),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.TeacherQualifications",
                c => new
                    {
                        QualificationId = c.Int(nullable: false, identity: true),
                        Degree = c.String(nullable: false, maxLength: 50),
                        PassingYear = c.Int(nullable: false),
                        Result = c.String(nullable: false, maxLength: 50),
                        Institute = c.String(nullable: false, maxLength: 50),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QualificationId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherQualifications", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Students", "AreaId", "dbo.Areas");
            DropIndex("dbo.TeacherQualifications", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "AreaId" });
            DropIndex("dbo.Students", new[] { "AreaId" });
            DropTable("dbo.TeacherQualifications");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Areas");
        }
    }
}

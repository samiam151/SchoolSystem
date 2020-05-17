namespace SchoolSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFluent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Student_Id", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "Student_Id" });
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            DropColumn("dbo.Courses", "Student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Student_Id", c => c.Int());
            DropForeignKey("dbo.StudentCourse", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourse", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentCourse", new[] { "CourseId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentId" });
            DropTable("dbo.StudentCourse");
            CreateIndex("dbo.Courses", "Student_Id");
            AddForeignKey("dbo.Courses", "Student_Id", "dbo.Students", "Id");
        }
    }
}

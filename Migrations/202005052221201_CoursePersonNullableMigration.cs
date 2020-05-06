namespace TrelloDesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoursePersonNullableMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CoursePersons", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CoursePersons", "PersonId", "dbo.People");
            DropIndex("dbo.CoursePersons", new[] { "CourseId" });
            DropIndex("dbo.CoursePersons", new[] { "PersonId" });
            AlterColumn("dbo.CoursePersons", "CourseId", c => c.Int());
            AlterColumn("dbo.CoursePersons", "PersonId", c => c.Int());
            CreateIndex("dbo.CoursePersons", "CourseId");
            CreateIndex("dbo.CoursePersons", "PersonId");
            AddForeignKey("dbo.CoursePersons", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.CoursePersons", "PersonId", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoursePersons", "PersonId", "dbo.People");
            DropForeignKey("dbo.CoursePersons", "CourseId", "dbo.Courses");
            DropIndex("dbo.CoursePersons", new[] { "PersonId" });
            DropIndex("dbo.CoursePersons", new[] { "CourseId" });
            AlterColumn("dbo.CoursePersons", "PersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.CoursePersons", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.CoursePersons", "PersonId");
            CreateIndex("dbo.CoursePersons", "CourseId");
            AddForeignKey("dbo.CoursePersons", "PersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CoursePersons", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}

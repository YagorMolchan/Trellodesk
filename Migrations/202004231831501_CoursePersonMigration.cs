namespace TrelloDesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoursePersonMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CoursePerson", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.CoursePerson", name: "Person_Id", newName: "PersonId");
            RenameIndex(table: "dbo.CoursePerson", name: "IX_Course_Id", newName: "IX_CourseId");
            RenameIndex(table: "dbo.CoursePerson", name: "IX_Person_Id", newName: "IX_PersonId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CoursePerson", name: "IX_PersonId", newName: "IX_Person_Id");
            RenameIndex(table: "dbo.CoursePerson", name: "IX_CourseId", newName: "IX_Course_Id");
            RenameColumn(table: "dbo.CoursePerson", name: "PersonId", newName: "Person_Id");
            RenameColumn(table: "dbo.CoursePerson", name: "CourseId", newName: "Course_Id");
        }
    }
}

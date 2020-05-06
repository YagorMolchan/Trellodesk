namespace TrelloDesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoursePersonMigration1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CoursePerson", newName: "CoursePersons");
            DropPrimaryKey("dbo.CoursePersons");
            AddColumn("dbo.CoursePersons", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CoursePersons", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CoursePersons");
            DropColumn("dbo.CoursePersons", "Id");
            AddPrimaryKey("dbo.CoursePersons", new[] { "CourseId", "PersonId" });
            RenameTable(name: "dbo.CoursePersons", newName: "CoursePerson");
        }
    }
}

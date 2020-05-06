namespace TrelloDesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Firstname = c.String(),
                        Secondname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CoursePerson",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Person_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Person_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Person_Id);
            
            DropColumn("dbo.Courses", "Subscribed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Subscribed", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.CoursePerson", "Person_Id", "dbo.People");
            DropForeignKey("dbo.CoursePerson", "Course_Id", "dbo.Courses");
            DropIndex("dbo.CoursePerson", new[] { "Person_Id" });
            DropIndex("dbo.CoursePerson", new[] { "Course_Id" });
            DropTable("dbo.CoursePerson");
            DropTable("dbo.People");
        }
    }
}

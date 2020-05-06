using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrelloDesk.Models.Entities;

namespace TrelloDesk.Data
{
    public class TrelloDeskContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Person> People { get; set; }

        public TrelloDeskContext():base("DefaultConnection")
        {

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>().HasMany<Person>(c => c.People)
        //        .WithMany(p => p.Courses)
        //        .Map(p =>
        //        {
        //            p.ToTable("CoursePerson");
        //            p.MapLeftKey("CourseId");
        //            p.MapRightKey("PersonId");
        //        });            
        //}
    }
}
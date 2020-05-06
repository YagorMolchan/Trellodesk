using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrelloDesk.Models.Entities
{
    public class CoursePerson
    {
        public int Id { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public int? PersonId { get; set; }
        public Person Person { get; set; }
    }
}
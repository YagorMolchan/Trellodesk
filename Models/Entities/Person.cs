using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrelloDesk.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Firstname { get; set; }

        public string Secondname { get; set; }        

        public virtual ICollection<CoursePerson> CoursePeople { get; set; }

        public Person()
        {
            CoursePeople = new List<CoursePerson>();
        }

        
    }
}
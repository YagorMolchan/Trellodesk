using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrelloDesk.Models.Entities;

namespace TrelloDesk.Models.ViewModels
{
    public class PersonListViewModel
    {
        public int CourseId { get; set; }
        public IEnumerable<Person> People { get; set; }

    }
}
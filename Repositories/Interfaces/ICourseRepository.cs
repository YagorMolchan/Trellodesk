using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloDesk.Models.Entities;

namespace TrelloDesk.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Course GetCourseById(int id);
        IEnumerable<Course> Courses { get; }
        void Create(Course course);
        void AddPersonToCourse(Course course, Person person);
        void RemovePersonFromCourse(Course course, Person person);
        void Save();
    }
}

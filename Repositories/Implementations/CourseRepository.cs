using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrelloDesk.Models.Entities;
using TrelloDesk.Repositories.Interfaces;
using TrelloDesk.Data;
using System.Data.Entity;

namespace TrelloDesk.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly TrelloDeskContext _dbContext;

        public CourseRepository()
        {
            _dbContext = new TrelloDeskContext();
        }

        public IEnumerable<Course> Courses => _dbContext.Courses.ToList<Course>();

        public void AddPersonToCourse(Course course, Person person)
        {
            course.CoursePeople.Add(new CoursePerson { Course = course, Person = person });
        }

        public void Create(Course course)
        {
            _dbContext.Courses.Add(course);
        }

        public Course GetCourseById(int id)
        {
            return _dbContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void RemovePersonFromCourse(Course course, Person person)
        {
            var coursePerson = _dbContext.Courses.SelectMany(c => c.CoursePeople).FirstOrDefault(c => c.CourseId == course.Id && c.PersonId == person.Id);
            if (coursePerson != null)
            {
                course.CoursePeople.Remove(coursePerson);
            }

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
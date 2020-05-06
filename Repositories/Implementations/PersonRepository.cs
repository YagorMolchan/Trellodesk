using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrelloDesk.Repositories.Interfaces;
using TrelloDesk.Models.Entities;
using TrelloDesk.Data;

namespace TrelloDesk.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TrelloDeskContext _dbContext;

        public PersonRepository()
        {
            _dbContext = new TrelloDeskContext();
        }

        public void Create(Person p)
        {
            _dbContext.People.Add(p);
        }

        //public void Delete(Person p)
        //{
        //    _dbContext.People.Remove(p);
        //}

        //public IEnumerable<string> GetNamesByCourseId(int courseId)
        //{
        //    return _dbContext.Courses.Where(c => c.Id == courseId).SelectMany(c => c.People).Select(c => c.Name).ToList<string>();
        //}

        public IEnumerable<Person> GetPersonsByCourseId(int courseId)
        {
            var coursePersons = _dbContext.Courses.SelectMany(c => c.CoursePeople).Where(c => c.CourseId == courseId);
            var people = coursePersons.Select(c => c.Person).ToList<Person>();
            return people;
        }

        public Person GetPersonByFirstnameAndSecondname(string firstname, string secondname)
        {
            return _dbContext.People.FirstOrDefault(p => p.Firstname == firstname && p.Secondname == secondname);
        }

        public Person GetPersonById(int personId)
        {
            return _dbContext.People.FirstOrDefault(p => p.Id == personId);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }



    }
}
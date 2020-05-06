using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloDesk.Models.Entities;

namespace TrelloDesk.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        void Create(Person p);
        //void Delete(Person p);
        Person GetPersonById(int personId);
        Person GetPersonByFirstnameAndSecondname(string firstname, string secondname);
        IEnumerable<Person> GetPersonsByCourseId(int courseId);
        //IEnumerable<string> GetNamesByCourseId(int courseId);
        void Save();

    }
}

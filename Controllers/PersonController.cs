using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrelloDesk.Data;
using TrelloDesk.Models.Entities;
using TrelloDesk.Models.ViewModels;
using TrelloDesk.Repositories.Interfaces;

namespace TrelloDesk.Controllers
{
    public class PersonController : Controller
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IPersonRepository _personRepo;

        public PersonController(ICourseRepository courseRepo, IPersonRepository personRepo)
        {
            _courseRepo = courseRepo;
            _personRepo = personRepo;
        }
        
        public ActionResult List(int courseId)
        {
            PersonListViewModel model = null;
            var people = _personRepo.GetPersonsByCourseId(courseId);
            model = new PersonListViewModel
            {
                CourseId = courseId,
                People = people
            };
            return View(model);
        }
    }
}

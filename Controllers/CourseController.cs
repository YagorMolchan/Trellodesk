using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrelloDesk.Models.ViewModels;
using TrelloDesk.Models.Entities;
using TrelloDesk.Repositories.Interfaces;
using TrelloDesk.Data;

namespace TrelloDesk.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IPersonRepository _personRepo;
        //private readonly TrelloDeskContext _dbContext;


        public CourseController(ICourseRepository courseRepo,IPersonRepository personRepo)
        {
            _courseRepo = courseRepo;
            _personRepo = personRepo;
            //    _dbContext = new TrelloDeskContext();
        }

        public ActionResult Index()
        {
            var courses = _courseRepo.Courses;
            return View(courses);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                    Name = model.Name,
                    Description = model.Description
                };
                _courseRepo.Create(course);
                _courseRepo.Save();
            }
            else
            {
                ModelState.AddModelError("", "Ошибка ввода!");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddPersonToCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPersonToCourse(PersonViewModel model, int courseId)
        {
            var course = _courseRepo.GetCourseById(courseId);
            ViewBag.CourseId = courseId;
            if (ModelState.IsValid)
            {
                var person = _personRepo.GetPersonByFirstnameAndSecondname(model.Firstname, model.Secondname);
                if (person != null)
                {
                    _courseRepo.AddPersonToCourse(course, person);
                    _courseRepo.Save();
                }
                else
                {
                    var name = model.Firstname + " " + model.Secondname;
                    person = new Person { Firstname = model.Firstname, Secondname = model.Secondname, Name = name };
                    _personRepo.Create(person);
                    _personRepo.Save();
                    _courseRepo.AddPersonToCourse(course, person);
                    _courseRepo.Save();
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult RemovePersonFromCourse(int courseId, int personId)
        {
            var person = _personRepo.GetPersonById(personId);
            if(person!=null)
            {
                var course = _courseRepo.GetCourseById(courseId);
                _courseRepo.RemovePersonFromCourse(course, person);
                _courseRepo.Save();
            }
            return RedirectToAction("GetPersonList", new { courseId = courseId });
                       
        }




        public ActionResult GetPersonList(int courseId)
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



        ////public ActionResult List()
        ////{
        ////    var courses = _dbContext.Courses.Where(c => c.Subscribed == true).ToList<Course>();
        ////    return View(courses);
        ////}
    }
}
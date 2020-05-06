using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using TrelloDesk.Repositories.Implementations;
using TrelloDesk.Repositories.Interfaces;

namespace TrelloDesk.Infrastructures.Ninject
{
    public class NinjectRegistrations:NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseRepository>().To<CourseRepository>();
            Bind<IPersonRepository>().To<PersonRepository>();
        }
    }
}
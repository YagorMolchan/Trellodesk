using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using TrelloDesk.Data;
using TrelloDesk.Infrastructures.Ninject;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using FluentValidation.Mvc;
using TrelloDesk.Infrastructures.Binders;

namespace TrelloDesk
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //ModelBinders.Binders.Add(typeof(int), new CourseModelBinder());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentValidationModelValidatorProvider.Configure();

            NinjectModule module = new NinjectRegistrations();
            var kernel = new StandardKernel(module);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

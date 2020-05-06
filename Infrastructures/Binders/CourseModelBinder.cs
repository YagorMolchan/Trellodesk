using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrelloDesk.Infrastructures.Binders
{
    public class CourseModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;
            int courseId = (int)valueProvider.GetValue("courseId").ConvertTo(typeof(int));
            return courseId;
        }
    }
}
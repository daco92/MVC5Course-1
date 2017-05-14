using System;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MVC5Course.ActionFilter
{
    internal class LocalOnlyAttribute : System.Web.Mvc.ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.RequestContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new RedirectResult("/");
            }

        }



    }
}
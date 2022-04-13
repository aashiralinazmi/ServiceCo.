using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceCo.Filters
{
    public class AuthorizedUser : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["IsLogin"] == null)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    { "Area", ""},
                    {"Controller", "Login" },
                    {"Action", "Login" }
                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
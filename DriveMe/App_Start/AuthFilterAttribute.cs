using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace DriveMe.App_Start
{
    public class AuthFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
    {

        void IAuthenticationFilter.OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.Session["IsLoggedIn"] == null)
            {
                //  filterContext.Result = new HttpUnauthorizedResult();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home" }));
            }           
        }

        void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }
    }
}

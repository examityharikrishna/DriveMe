using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace DriveMe.App_Start
{
    public class SecureControllerRouteFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Session["IsLoggedIn"] != null)
            {
                DriveMe.Models.User user = (DriveMe.Models.User)filterContext.HttpContext.Session["User"];
                string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();

                if (user.Role.Name.ToLower() == "admin" &&(controller=="rides")) {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
                else if (user.Role.Name.ToLower() == "customer" && controller == "drivers")
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
        }
    }
}
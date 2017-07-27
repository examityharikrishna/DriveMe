using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DriveMe.App_Start;

namespace DriveMe.Controllers
{
    public class DashboardController : Controller
    {
        [AuthFilterAttribute]        
        public ActionResult Index()
        {
            return View("Dashboard");
        }
      
        public ActionResult OpenLogin()
        {
            return PartialView("_Login");
        }

        public ActionResult OpenRegister()
        {
            return PartialView("_Register");
        }
    }
}
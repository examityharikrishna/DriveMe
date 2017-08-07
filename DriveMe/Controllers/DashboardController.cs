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
            if (Session["User"] != null && ((DriveMe.Models.User)Session["User"]).Role.Name.ToLower() == "admin")
            {
                return View("Dashboard");
            }
            else {
                return View("cdb");
            }
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
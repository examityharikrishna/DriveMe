using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DriveMe.Controllers
{
    public class DriverController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("all")]
        public ActionResult GetDrivers()
        {
            return View("drivers");
        }
    }
}
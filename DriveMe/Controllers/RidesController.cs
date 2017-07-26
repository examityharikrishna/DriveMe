using DriveMe.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DriveMe.Controllers 
{
    public class RidesController : Controller
    {
        // GET: Rides
        [AuthFilterAttribute] 
        [ActionName("rides")]       
        public ActionResult Index()
        {
            return View("Index");
        }

        [ActionName("new")]
        public ActionResult Create()
        {
            return View("create");
        }
    }
}
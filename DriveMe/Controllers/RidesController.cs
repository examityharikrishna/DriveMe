using DriveMe.App_Start;
using DriveMe.DBEntities;
using DriveMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DriveMe.Controllers 
{
    public class RidesController : Controller
    {
        DriveMeEntities _context = null;
        public RidesController()
        {
            _context = new DriveMeEntities();
        }

        // GET: Rides
        [AuthFilterAttribute] 
        [ActionName("rides")]       
        public ActionResult Index()
        {
            return View("Index");
        }

        [ActionName("new")]
        //[AuthFilterAttribute]
        public ActionResult Create()
        {
            BookRideViewModel obj = new BookRideViewModel();
            foreach (var type in _context.RideTypes) {
                obj.RideTypes.Add(new ViewModels.RideType {Id=type.Id, Name=type.Name });
            }
            foreach (var type in _context.RideModes)
            {
                obj.RideModes.Add(new ViewModels.RideMode { Id = type.Id, Name = type.Name });
            }
            return View("newride", obj);
        }       
       
        [HttpPost]
        [ActionName("new")]
        //[AuthFilterAttribute]
        public ActionResult Create(BookRideViewModel obj)
        {
            Ride objc = new DBEntities.Ride();
            objc.From = obj.From;
            objc.To = obj.To;
            objc.RideType = obj.RideType;
            objc.RideMode = obj.RideMode;
            objc.NumberOfPersons = obj.NunberOfPersons;
            objc.UserId = ((DriveMe.Models.User)Session["User"]).Id;
            _context.Rides.Add(objc);

            _context.SaveChanges();
            return RedirectToAction("rides");
        }
    }
}
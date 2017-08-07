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
            
            DriveMe.Models.User user = ((DriveMe.Models.User)Session["User"]);
            List<Ride> lstRides = _context.Rides.Where(r => r.UserId == user.Id).ToList();
            List<DriveMe.Models.Ride> userRides = new List<Models.Ride>();
            foreach (var ride in lstRides)
            {
                DriveMe.Models.Ride obj = new Models.Ride();
                obj.From = ride.From;
                obj.To = ride.To;
                obj.NumberOfPersons = ride.NumberOfPersons;
                obj.DateOfRide = ride.Datetime;
                obj.RideId = ride.Id;
                obj.RideMode = _context.RideModes.SingleOrDefault(r => r.Id == ride.RideMode).Name;
                obj.RideType = _context.RideModes.SingleOrDefault(r => r.Id == ride.RideType).Name;
                userRides.Add(obj);
            }
            return View("Index",userRides);
        }

        [ActionName("new")]
        //[AuthFilterAttribute]
        public ActionResult Create()
        {
            BookRideViewModel obj = new BookRideViewModel();
            foreach (var type in _context.RideTypes)
            {
                obj.RideTypes.Add(new ViewModels.RType { Id = type.Id, Name = type.Name });
            }
            foreach (var type in _context.RideModes)
            {
                obj.RideModes.Add(new ViewModels.RMode { Id = type.Id, Name = type.Name });
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
            objc.RideType = obj.RideTypeId;
            objc.RideMode = obj.RideModeId;
            objc.NumberOfPersons = obj.NunberOfPersons;
            objc.Datetime = obj.Datetime;
            objc.UserId = ((DriveMe.Models.User)Session["User"]).Id;
            _context.Rides.Add(objc);

            _context.SaveChanges();
            return RedirectToAction("rides");
        }
    }
}
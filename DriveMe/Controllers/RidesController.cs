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
    [AuthFilterAttribute]
    [SecureControllerRouteFilter]
    public class RidesController : Controller
    {
        DriveMeEntities _context = null;
        public RidesController()
        {
            _context = new DriveMeEntities();
        }

        [ActionName("rides")]
        public ActionResult Index()
        {

            DriveMe.Models.User user = ((DriveMe.Models.User)Session["User"]);
            List<Ride> lstRides = _context.Rides.Where(r => r.UserId == user.Id).ToList();
            List<DriveMe.ViewModels.RideViewModel> userRides = new List<ViewModels.RideViewModel>();
            foreach (var ride in lstRides)
            {
                DriveMe.ViewModels.RideViewModel obj = new ViewModels.RideViewModel();
                obj.From = ride.From;
                obj.To = ride.To;
                obj.NumberOfPersons = ride.NumberOfPersons;
                obj.DateOfRide = ride.Datetime;
                obj.RideId = ride.Id;
                obj.RideMode = _context.RideModes.SingleOrDefault(r => r.Id == ride.RideMode).Name;
                obj.RideType = _context.RideTypes.SingleOrDefault(r => r.Id == ride.RideType).Name;
                obj.Status = Enum.GetName(typeof(DriveMe.Models.Status), ride.Status);
                userRides.Add(obj);
            }
            return View("Index", userRides);
        }

        [ActionName("new")]
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
            objc.Status = (int)DriveMe.Models.Status.PendingApproval;
            _context.Rides.Add(objc);

            _context.SaveChanges();
            return RedirectToAction("rides");
        }
    }
}
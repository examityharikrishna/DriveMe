using DriveMe.App_Start;
using DriveMe.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DriveMe.Controllers
{
    [AuthFilterAttribute]
    [SecureControllerRouteFilter]
    public class DriverController : Controller
    {
        DriveMeEntities _context = null;
        public DriverController()
        {
            _context = new DriveMeEntities();
        }
        public ActionResult Index()
        {
            List<User> lstUser = _context.Users.Where(u => u.Role.Id == 3).ToList();
            List<DriveMe.ViewModels.DriverViewModel> lstDrivers = new List<ViewModels.DriverViewModel>();
            foreach (var user in lstUser) {
                DriveMe.ViewModels.DriverViewModel obj = new ViewModels.DriverViewModel();
                obj.Email = user.Email;
                obj.Name = user.Name;
                obj.Mobile = user.Mobile;
                obj.Type = user.Drivertype;
                lstDrivers.Add(obj);
            }
            return View("drivers", lstDrivers);
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        public ActionResult Create(DriveMe.ViewModels.newDriver obj) {

            _context.Users.Add(new DBEntities.User {
                Email = obj.Email,
                Name = obj.Name,
                Mobile=obj.Mobile,
                RoleId=3,//Driver role
                Password="password$"                
            });
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
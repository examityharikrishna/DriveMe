﻿using DriveMe.DBEntities;
using DriveMe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DriveMe.Controllers{
   
    public class LoginController : Controller
    {
        DriveMeEntities _context = null;
        public LoginController()
        {
            _context = new DriveMeEntities();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Register(RegisterViewModel objRegister)
        {
            _context.Users.Add(new User()
            {
                Name = objRegister.UserName,
                Email = objRegister.Email,
                Mobile = objRegister.Mobile,
                Password = objRegister.Password,
                RoleId = _context.Roles.FirstOrDefault(r => r.Name == "driver").Id
            });
            _context.SaveChanges();
            return PartialView("_Register", new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult DoLogin(LoginViewModel objLogin)
        {          
            DBEntities.User foundUser = _context.Users.SingleOrDefault(u => u.Email == objLogin.Email && u.Password == objLogin.Password);
            if (foundUser == null)
            {
                ModelState.AddModelError(string.Empty, "invalid username or password");
                return PartialView("_Login",objLogin);
            }
            Session["IsLoggedIn"] = 1;
            Session["User"] = new LoginViewModel {Email=foundUser.Email, UserName=foundUser.Name };
            return Json("success");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveMe.Models
{
    public class User
    {
        public User()
        {
            Role = new Role();
        }
        public int Id { get; set; }
        public string Password { get; set; }       
        public string Email { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
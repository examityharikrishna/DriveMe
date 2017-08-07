using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveMe.Models
{
    public class Ride
    {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DateOfRide { get; set; }
        public string RideType { get; set; }        
        public string RideMode { get; set; }
        public int NumberOfPersons { get; set; }
    }
}
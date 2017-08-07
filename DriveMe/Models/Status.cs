using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveMe.Models
{
    public enum Status
    {
        PendingApproval=1,
        DriverAssigned=2,
        DriverOnTheWay=3,
        DriverAarrived=4,
    }
}
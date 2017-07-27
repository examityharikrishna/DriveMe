using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DriveMe.ViewModels
{
    public class BookRideViewModel
    {
        public BookRideViewModel()
        {
            this.RideTypes = new List<ViewModels.RideType>();
            this.RideModes = new List<ViewModels.RideMode>();
            this.Datetime = DateTime.Now;
            this.NunberOfPersons = 1;
        }
        
        [Required]
        [Display(Name ="Ride type")]
        public int RideType { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        [Display(Name ="Ride Date and Time")]
         [DataType(DataType.Date)]
        public DateTime Datetime { get; set; }
        [Required]
        [Display(Name ="Ride mode")]
        public int RideMode { get; set; }
        [Required]
        [Display(Name ="Number of persons")]
        [Range(1,5,ErrorMessage ="At most 5 persons allowed")]
        [RegularExpression(@"^\d$",ErrorMessage ="Only numbers allowed")]
        
        public int NunberOfPersons { get; set; }

        public List<RideType> RideTypes { get; set; }
        public List<RideMode> RideModes { get; set; }
    }
    public class RideType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class RideMode
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
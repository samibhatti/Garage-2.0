using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class Vehicle
    {

        //[RegularExpression("^[A-Z]{3} [0-9]{3}$", ErrorMessage = "Need to be in format AAA 123")]
        //[RegularExpression("^[A-Z]{3}\\d{3}$", ErrorMessage = "Requires 3 letter follow by 3 numbers")]
        [Key]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Parking lot number")]
        public string ParkingLotNumber { get; set; }

        [Required]
        public DateTime ParkingStartTime { get; set; }

        [Display(Name = "Number of tyres")]
        public int NumberOfTyres { get; set; }

        [StringLength(50)]
        [Display(Name = "Fabricate model")]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        // Navigation Properties
        public virtual VehicleType VehicleType { get; set; }

        //Maybe unnecessary due to already being set by default [ForeignKey("Member")]
        public string MemberId { get; set; }
        public virtual Member Member { get; set; }
        

    }
}
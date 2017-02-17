using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        //[RegularExpression("^[A-Z]{3} [0-9]{3}$", ErrorMessage = "Need to be in format AAA 123")]
        //[RegularExpression("^[A-Z]{3}\\d{3}$", ErrorMessage = "Requires 3 letter follow by 3 numbers")]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        [Required]
        public VehicleTypeName VehicleTypeName { get; set; }

        [StringLength(20)]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Parking lot number")]
        public string ParkingLotNo { get; set; }

        public int VehicleLength { get; set; }

        [Required]
        public DateTime ParkingStartTime { get; set; }


        [Display(Name = "Number of tyres")]
        public int NoOfTyres { get; set; }

        [StringLength(50)]
        [Display(Name = "Fabricate model")]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Fabricate")]
        public string Fabricate { get; set; }
    }
}
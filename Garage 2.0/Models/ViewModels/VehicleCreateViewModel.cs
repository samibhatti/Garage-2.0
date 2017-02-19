using Garage_2._0.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3} [0-9]{3}$", ErrorMessage = "Need to be in format AAA 123")]
        [Remote("RegNr", "Validate", ErrorMessage = "Registration Number is alreay parked")]
        //[RegularExpression("^[A-Z]{3}\\d{3}$", ErrorMessage = "Requires 3 letter follow by 3 numbers")]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        [Required]
        public VehicleType VehicleType;

        [StringLength(20)]
        [Display(Name = "Color")]
        public string Color { get; set; }

        //[Required]
        [Display(Name = "Parking lot number")]
        [Remote("checkParkingLotNr", "Validate", ErrorMessage = "Parkinglot taken")]
        public string ParkingLotNumber { get; set; }

        [Required]
        public DateTime ParkingStartTime { get; set; }

        [Range(0, 4, ErrorMessage = "Tyres must be 2 or 4")]
        [Display(Name = "Number of tyres")]
        [Remote("checkNumberOfTyres", "Validate", ErrorMessage = "Invalid number of tyres")]
        public int NumberOfTyres { get; set; }

        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        public int MemberId { get; set; }

        public List<string> FreeParking { get; set; }
        public List<VehicleType> VehicleTypeList { get; set; }

       
    }
}
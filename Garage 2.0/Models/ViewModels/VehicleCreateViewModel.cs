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
        public int MemberId { get; set; }

        public string FullName { get; set; }

        [Display(Name = "Parking lot number")]
        public string ParkingLotNumber { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required]
        public int VehicleTypeId { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Number of tyres")]
        public int NumberOfTyres { get; set; }

        [Required]
        public string VModel { get; set; }

        [Required]
        public string Brand { get; set; }

        public DateTime ParkingStartTime { get; set; }

        public SelectList FreeParking { get; set; }
        public SelectList VehicleTypeList { get; set; }
        public SelectList MemberList { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage_2._0.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleIndexViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Reg Nr")]
        public string RegNr { get; set; }
        [Display(Name = "Member Id")]
        public int MemberId { get; set; }
        [Display(Name = "Vehicle Type")]
        public int VehicleTypeId { get; set; }
        [Display(Name = "Vehicle Type")]
        public string VehicleTypeName { get; set; }
        [Display(Name = "Lot Nr")]
        public string ParkingLotNumber { get; set; }
        [Display(Name = "Start Parking Time")]
        public DateTime ParkingStartTime { get; set; }
        public string Duration { get; set; }
        public string Modell { get; set; }
        public string Brand { get; set; }

        [Display(Name = "Owner")]
        public string MemberFullName { get; set; }
    }
}
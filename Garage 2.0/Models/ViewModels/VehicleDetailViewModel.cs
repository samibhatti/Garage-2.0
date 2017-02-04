using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleDetailViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Member Member { get; set; }

        /*
        public string MemberFullName { get; set; }
        public int MyProperty { get; set; }

        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        public int VehicleTypeName { get; set; }

        [Display(Name = "Parking Lot")]
        public string ParkingLotNumber { get; set; }

        [Display(Name = "Vehicle Model")]
        public string Model { get; set; }

        [Display(Name = "Vehicle Brande")]
        public string Brand { get; set; }

        [Display(Name = "Parking Start Time")]
        public DateTime ParkingStartTime { get; set; }

        public VehicleDetailViewModel(string regNr)
        {
            RegNr = regNr;
        }
        */
    }
}
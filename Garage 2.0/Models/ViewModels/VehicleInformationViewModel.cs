using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleInformationViewModel
    {
        [Display(Name = "Total Vehicle")]
        public int TotalVehicle { get; set; }

        [Display(Name = "Total Sedan")]
        public int Sedan { get; set; }

        [Display(Name = "Total Airplane")]
        public int Airplane { get; set; }

        [Display(Name = "Total Car")]
        public int Car { get; set; }

        [Display(Name = "Total MiniBus")]
        public int MiniBus { get; set; }

        [Display(Name = "Total Motorbike")]
        public int Motorbike { get; set; }

        [Display(Name = "Total Train")]
        public int Train { get; set; }

        [Display(Name = "Number of Bus")]
        public int Bus { get; set; }

        [Display(Name = "Number of Boat")]
        public int Boat { get; set; }

        [Display(Name = "Number of Tyres")]
        public int NumberOfTyres { get; set; }

        [Display(Name = "Incoming payments")]
        public int CostToThisMoment { get; set; }

        [Display(Name = "Parking slots information")]
        public List<string> ParkingInfo { get; set; }

    }
}
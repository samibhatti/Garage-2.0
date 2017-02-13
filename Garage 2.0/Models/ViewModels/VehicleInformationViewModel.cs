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
        [Display(Name = "Total Kombi")]
        public int Kombi { get; set; }
        [Display(Name = "Total Vagon")]
        public int Vagon { get; set; }
        [Display(Name = "Total MiniBus")]
        public int MiniBus { get; set; }
        [Display(Name ="Total Motorcycle")]
        public int MotorCycle { get; set; }
        [Display(Name = "Total Pickup")]
        public int Pickup { get; set; }
        [Display(Name = "Number of tyres")]
        public int NumberOfTyres { get; set; }
        [Display(Name = "Incoming payments")]
        public int CostToThisMoment { get; set; }
        [Display(Name = "Parking slots information")]
        public List<string> ParkingInfo { get; set; }

    }
}
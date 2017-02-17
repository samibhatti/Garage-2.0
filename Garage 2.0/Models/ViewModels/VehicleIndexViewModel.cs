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
        public int VehicleTypeId { get; set; }
        [Display(Name = "Lot Nr")]
        public string ParkingLotNumber { get; set; }
        [Display(Name = "Start Parking Time")]
        public DateTime ParkingStartTime { get; set; }
        public string Duration { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }

        public VehicleIndexViewModel(string regNr, int vehicleTypeId, string parkingLotNumber,
            DateTime parkingStartTime, string model, string brand)
        {
            RegNr = regNr;
            VehicleTypeId = vehicleTypeId;
            ParkingLotNumber = parkingLotNumber;
            ParkingStartTime = parkingStartTime;
            Duration = ParkingHelper.GetDuration(parkingStartTime);
            Model = model;
            Brand = brand;
        }
    }
}
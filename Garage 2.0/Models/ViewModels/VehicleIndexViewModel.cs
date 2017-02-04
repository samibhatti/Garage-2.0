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
        public VehicleTypeName VehicleTypeName { get; set; }
        [Display(Name = "Lot Nr")]
        public string ParkingLotNo { get; set; }
        [Display(Name = "Start Parking Time")]
        public DateTime ParkingStartTime { get; set; }
        public string Duration { get; set; }
        public string Model { get; set; }
        public string Fabricate { get; set; }
        public IList<VehicleIndexViewModel> Vehicles { get; set; }

        public VehicleIndexViewModel toViewModel(Vehicle vehicle)
        {
            VehicleIndexViewModel model = new VehicleIndexViewModel
            {
                RegNr = vehicle.RegNr,
                VehicleTypeName = VehicleTypeName,
                ParkingLotNo = vehicle.ParkingLotNumber,
                ParkingStartTime = vehicle.ParkingStartTime,
                Duration = ParkingHelper.GetDuration(vehicle.ParkingStartTime),
                Model = vehicle.Model,
                Fabricate = vehicle.Brand
            };
            return model;
        }

        public List<VehicleIndexViewModel> toList(List<Vehicle> vehicles)
        {
            List<VehicleIndexViewModel> model = new List<VehicleIndexViewModel>();
            foreach(var vehicle in vehicles)
            {
                model.Add(toViewModel(vehicle));
            }
            return model;
        }
    }
}
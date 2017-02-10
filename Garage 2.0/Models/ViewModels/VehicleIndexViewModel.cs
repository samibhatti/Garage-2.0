using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage_2._0.Helpers;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleIndexViewModel
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public VehicleTypeName VehicleTypeName { get; set; }
        public string ParkingLotNo { get; set; }
        public DateTime ParkingStartTime { get; set; }
        public string Duration { get; set; }
        public string Model { get; set; }
        public string Fabricate { get; set; }
        public IList<VehicleIndexViewModel> Vehicles { get; set; }

        public VehicleIndexViewModel toViewModel(Vehicle vehicle)
        {
            VehicleIndexViewModel model = new VehicleIndexViewModel
            {
                Id = vehicle.Id,
                RegNr = vehicle.RegNr,
                VehicleTypeName = VehicleTypeName,
                ParkingLotNo = vehicle.ParkingLotNo,
                ParkingStartTime = vehicle.ParkingStartTime,
                Duration = parkingHelper.getDuration(vehicle.ParkingStartTime),
                Model = vehicle.Model,
                Fabricate = vehicle.Fabricate
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
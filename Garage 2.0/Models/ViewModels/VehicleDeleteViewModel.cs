using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage_2._0.Helpers;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleDeleteViewModel
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public VehicleTypeName VehicleTypeName { get; set; }
        public string Color { get; set; }
        public string ParkingLotNo { get; set; }
        public int VehicleLength { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime ParkingStartTime { get; set; }
        public DateTime ParkingStopTime { get; set; }
        public int NoOfTyres { get; set; }
        public string Model { get; set; }
        public string Fabricate { get; set; }
        public int PaymentAmount { get; set; }

        public string Duration { get; set; }

        public VehicleDeleteViewModel toViewModel(Vehicle vehicle)
        {
            VehicleDeleteViewModel model = new VehicleDeleteViewModel
            {
                Id = vehicle.Id,
                RegNr = vehicle.RegNr,
                VehicleTypeName = VehicleTypeName,
                Color = vehicle.Color,
                ParkingLotNo = vehicle.ParkingLotNumber,
                ParkingStartTime = vehicle.ParkingStartTime,
                ParkingStopTime = DateTime.Now,
                NoOfTyres = vehicle.NumberOfTyres,
                Model = vehicle.Modell,
                Fabricate = vehicle.Brand,
                Duration = ParkingHelper.GetDuration(vehicle.ParkingStartTime),
                PaymentAmount = ParkingHelper.GetCost(vehicle.ParkingStartTime)
            };
            return model;
        }
    }
}
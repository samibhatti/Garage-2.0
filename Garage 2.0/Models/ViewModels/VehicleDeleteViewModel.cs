using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleDeleteViewModel
    {
        public int id { get; set; }
        public string RegNr { get; set; }
        public string VehicleTypeName { get; set; }
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

        public string duration(DateTime startTime)
        {
            int days = (DateTime.Now - startTime).Days;
            int hours = (DateTime.Now - startTime).Hours;
            int minuts = (DateTime.Now - startTime).Minutes;
            string duration = days + " Days " + hours + " Hours " + minuts + " Minuts";
            return duration;
        }

        public VehicleDeleteViewModel toViewModel(Vehicle vehicle)
        {
            VehicleDeleteViewModel model = new VehicleDeleteViewModel
            {
                id = vehicle.Id,
                RegNr = vehicle.RegNr,
                VehicleTypeName = vehicle.VehicleTypeName,
                Color = vehicle.Color,
                ParkingLotNo = vehicle.ParkingLotNo,
                VehicleLength = vehicle.VehicleLength,
                NumberOfSeats = vehicle.NumberOfSeats,
                ParkingStartTime = vehicle.ParkingStartTime,
                ParkingStopTime = DateTime.Now,
                NoOfTyres = vehicle.NoOfTyres,
                Model = vehicle.Model,
                Fabricate = vehicle.Fabricate,
                Duration = duration(vehicle.ParkingStartTime),
                PaymentAmount = paymentAmount(vehicle.ParkingStartTime)
            };
            return model;
        }

        public int  paymentAmount(DateTime startTime)
        {
            int days = (DateTime.Now - startTime).Days;
            int hours = (DateTime.Now - startTime).Hours;
            int minuts = (DateTime.Now - startTime).Minutes;
            int amount = (days * 24 * 60) + (hours * 60) + (minuts * 1);
            return amount;
        }
    }
}
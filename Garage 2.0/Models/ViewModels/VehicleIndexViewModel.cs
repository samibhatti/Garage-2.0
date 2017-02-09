using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleIndexViewModel
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public string VehicleTypeName { get; set; }
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
                VehicleTypeName = vehicle.VehicleTypeName,
                ParkingLotNo = vehicle.ParkingLotNo,
                ParkingStartTime = vehicle.ParkingStartTime,
                Duration = duration(vehicle.ParkingStartTime),
                Model = vehicle.Model,
                Fabricate = vehicle.Fabricate
            };
            return model;
        }

        public string duration(DateTime startTime)
        {
            int days = (DateTime.Now - startTime).Days;
            int hours = (DateTime.Now - startTime).Hours;
            int minuts = (DateTime.Now - startTime).Minutes;
            string duration = days + " Days " + hours + " Hours " + minuts + " Minuts";
            return duration;
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
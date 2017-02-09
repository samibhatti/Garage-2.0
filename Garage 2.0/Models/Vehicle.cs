using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public  string RegNr { get; set; }
        public  VehicleTypeName VehicleTypeName { get; set; }
        public  string Color { get; set; }
        public  string ParkingLotNo { get; set; }
        public  int VehicleLength { get; set; }
        public DateTime ParkingStartTime { get; set; }
        public int NoOfTyres { get; set; }
        public string Model { get; set; }
        public string Fabricate { get; set; }
    }
}
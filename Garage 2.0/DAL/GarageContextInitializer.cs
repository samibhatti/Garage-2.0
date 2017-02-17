using Garage_2._0.Models;
using System;
using System.Data.Entity;

namespace Garage_2._0.DAL
{
    internal class GarageContextInitializer : DropCreateDatabaseAlways<Garage_2_5_Context>
    {
        protected override void Seed(Garage_2_5_Context context)
        {
            var members = new Member[]
            {
                new Member {FirstName = "Adam", LastName = "Andersson"},
                new Member {FirstName = "Bertil", LastName = "Larsson"},
                new Member {FirstName = "Cecilia", LastName = "Eriksson"},
                new Member {FirstName = "Diana", LastName = "Svensson"},
                new Member {FirstName = "Erik", LastName = "Bergqvist"},

            };

            context.Members.AddRange(members);
            context.SaveChanges();

            var vehicles = new Vehicle[]
            {
                new Vehicle { RegNr = "PPA 434", Color = "Black", ParkingLotNumber = "A1",  ParkingStartTime = DateTime.Now, NumberOfTyres = 4, Model = "V6",  Brand  = "Volvo" },
                new Vehicle { RegNr = "QGK 443", Color = "Blue", ParkingLotNumber = "A2",   ParkingStartTime = DateTime.Now, NumberOfTyres = 2, Model = "V7",  Brand = "Honda" },
                new Vehicle { RegNr = "RPG 454", Color = "Pink", ParkingLotNumber = "A3",   ParkingStartTime = DateTime.Now, NumberOfTyres = 4, Model = "V9",  Brand = "Mazda" },
                new Vehicle { RegNr = "TFK 466", Color = "Red", ParkingLotNumber = "A4",    ParkingStartTime = DateTime.Now,  NumberOfTyres = 4, Model = "V2", Brand = "Nissan" },
                new Vehicle { RegNr = "MPJ 748", Color = "White", ParkingLotNumber = "A5",  ParkingStartTime = DateTime.Now,  NumberOfTyres = 4, Model = "V4", Brand = "BMW" },
                new Vehicle { RegNr = "ZWK 844", Color = "Silver", ParkingLotNumber = "A6", ParkingStartTime = DateTime.Now, NumberOfTyres = 4, Model = "V9",  Brand = "Scania" },
                new Vehicle { RegNr = "PTA 434", Color = "Black", ParkingLotNumber = "A7",  ParkingStartTime = DateTime.Now, NumberOfTyres = 4, Model = "V6",  Brand = "Volvo" },
                new Vehicle { RegNr = "QGK 443", Color = "Blue", ParkingLotNumber = "A8",   ParkingStartTime = DateTime.Now, NumberOfTyres = 2, Model = "V4",  Brand = "Honda" },
                new Vehicle { RegNr = "RPG 454", Color = "Pink", ParkingLotNumber = "A9",   ParkingStartTime = DateTime.Now,  NumberOfTyres = 4, Model = "V3", Brand = "Mazda" },
                new Vehicle { RegNr = "TFK 466", Color = "Red", ParkingLotNumber = "A10",   ParkingStartTime = DateTime.Now,  NumberOfTyres = 4, Model = "V7", Brand = "Nissan" }
            };

            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();

            var vehicleTypes = new VehicleType[]
            {
                new VehicleType {Name = "Airplane" },
                new VehicleType {Name = "Train" },
                new VehicleType {Name = "Car" },
                new VehicleType {Name = "MiniBus" },
                new VehicleType {Name = "Bus" },
                new VehicleType {Name = "Motorbike" },
                new VehicleType {Name = "Boat" },
                new VehicleType {Name = "Sedan" },
            };

            context.VehicleTypes.AddRange(vehicleTypes);
            context.SaveChanges();
        }
    }
}
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
                new Member {FirstName = "Adam", LastName = "Andersson", PhoneNumber = "0700000000"},
                new Member {FirstName = "Bertil", LastName = "Larsson", PhoneNumber = "0700000000"},
                new Member {FirstName = "Cecilia", LastName = "Eriksson", PhoneNumber = "0700000000"},
                new Member {FirstName = "Diana", LastName = "Svensson", PhoneNumber = "0700000000"},
                new Member {FirstName = "Erik", LastName = "Bergqvist", PhoneNumber = "0700000000"},

            };

            context.Members.AddRange(members);
            context.SaveChanges();

            var vehicles = new Vehicle[]
            {
                new Vehicle { RegNr = "PPA 434", Color = "Black", ParkingLotNumber = "A1", MemberId = members[1].MemberId  ,ParkingStartTime = DateTime.Now, NumberOfTyres = 4, Model = "V6",  Brand  = "Volvo", VehicleType = new VehicleType { Name = "Airplane" } },
                new Vehicle { RegNr = "QGK 444", Color = "Blue", ParkingLotNumber = "A2",  MemberId = members[0].MemberId, ParkingStartTime = DateTime.Now, NumberOfTyres = 2, Model = "V7",  Brand = "Honda", VehicleType = new VehicleType { Name = "Boat" }}, 
                new Vehicle { RegNr = "RPG 454", Color = "Pink", ParkingLotNumber = "A3",  MemberId = members[2].MemberId, ParkingStartTime = DateTime.Now, NumberOfTyres = 4, Model = "V9",  Brand = "Mazda", VehicleType = new VehicleType { Name = "Car" }},
                new Vehicle { RegNr = "TFK 466", Color = "Red", ParkingLotNumber = "A4",   MemberId = members[0].MemberId, ParkingStartTime = DateTime.Now,  NumberOfTyres = 4, Model = "V2", Brand = "Nissan", VehicleType = new VehicleType { Name = "Motorbike" } },
                new Vehicle { RegNr = "MPJ 748", Color = "White", ParkingLotNumber = "A5", MemberId = members[3].MemberId, ParkingStartTime = DateTime.Now,  NumberOfTyres = 4, Model = "V4", Brand = "BMW", VehicleType = new VehicleType { Name = "Train" } },
                new Vehicle { RegNr = "ZWK 844", Color = "Silver", ParkingLotNumber = "A6",MemberId = members[1].MemberId, ParkingStartTime = DateTime.Now, NumberOfTyres = 4, Model = "V9",  Brand = "Scania", VehicleType = new VehicleType { Name = "Airplane" } },
                new Vehicle { RegNr = "PTA 434", Color = "Black", ParkingLotNumber = "A7", MemberId = members[4].MemberId, ParkingStartTime = DateTime.Now, NumberOfTyres = 4, Model = "V6",  Brand = "Volvo", VehicleType = new VehicleType { Name = "Train" } },
                new Vehicle { RegNr = "QGK 443", Color = "Blue", ParkingLotNumber = "A8",  MemberId = members[2].MemberId, ParkingStartTime = DateTime.Now, NumberOfTyres = 2, Model = "V4",  Brand = "Honda", VehicleType = new VehicleType { Name = "MiniBus" } },
                new Vehicle { RegNr = "RPG 455", Color = "Pink", ParkingLotNumber = "A9",  MemberId = members[1].MemberId, ParkingStartTime = DateTime.Now,  NumberOfTyres = 4, Model = "V3", Brand = "Mazda", VehicleType = new VehicleType { Name = "Bus" }},
                new Vehicle { RegNr = "TFK 467", Color = "Red", ParkingLotNumber = "A10",  MemberId = members[0].MemberId, ParkingStartTime = DateTime.Now,  NumberOfTyres = 4, Model = "V7", Brand = "Nissan", VehicleType = new VehicleType { Name = "Sedan" } }
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
namespace Garage_2._0.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage_2._0.DAL.Garage_2_0_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Garage_2._0.DAL.Garage_2_0_Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Vehicles.AddRange(new List<Vehicle> {
                new Vehicle { Id = 1, RegNr = "PPA 434", VehicleTypeName = VehicleTypeName.MiniBus, Color = "Black", ParkingLotNo = "A1", VehicleLength = 2990, ParkingStartTime = DateTime.Now, NoOfTyres = 4, Model = "V6", Fabricate = "Volvo" },
                new Vehicle { Id = 2, RegNr = "QGK 443", VehicleTypeName = VehicleTypeName.Motorcycle, Color = "Blue", ParkingLotNo = "A2", VehicleLength = 7876,  ParkingStartTime = DateTime.Now, NoOfTyres = 2, Model = "V6", Fabricate = "Honda" },
                new Vehicle { Id = 3, RegNr = "RPG 454", VehicleTypeName = VehicleTypeName.Kombi, Color = "Pink", ParkingLotNo = "A3", VehicleLength = 3790,  ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Mazda" },
                new Vehicle { Id = 4, RegNr = "TFK 466", VehicleTypeName = VehicleTypeName.Sedan, Color = "Red", ParkingLotNo = "A4", VehicleLength = 2874, ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Nissan" },
                new Vehicle { Id = 5, RegNr = "MPJ 748", VehicleTypeName = VehicleTypeName.Vagen, Color = "White", ParkingLotNo = "A5", VehicleLength = 4765,  ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "BMW" },
                new Vehicle { Id = 6, RegNr = "ZWK 844", VehicleTypeName = VehicleTypeName.Pickup, Color = "Silver", ParkingLotNo = "A6", VehicleLength = 6743, ParkingStartTime = DateTime.Now, NoOfTyres = 4, Model = "V6", Fabricate = "Scania" },
                new Vehicle { Id = 7, RegNr = "PTA 434", VehicleTypeName = VehicleTypeName.MiniBus, Color = "Black", ParkingLotNo = "A7", VehicleLength = 2990, ParkingStartTime = DateTime.Now, NoOfTyres = 4, Model = "V6", Fabricate = "Volvo" },
                new Vehicle { Id = 8, RegNr = "QGK 443", VehicleTypeName = VehicleTypeName.Motorcycle, Color = "Blue", ParkingLotNo = "A8", VehicleLength = 7876,  ParkingStartTime = DateTime.Now, NoOfTyres = 2, Model = "V6", Fabricate = "Honda" },
                new Vehicle { Id = 9, RegNr = "RPG 454", VehicleTypeName = VehicleTypeName.Kombi, Color = "Pink", ParkingLotNo = "A9", VehicleLength = 3790,  ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Mazda" },
                new Vehicle { Id = 10, RegNr = "TFK 466", VehicleTypeName = VehicleTypeName.Sedan, Color = "Red", ParkingLotNo = "A10", VehicleLength = 2874, ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Nissan" },
                new Vehicle { Id = 11, RegNr = "QPA 434", VehicleTypeName = VehicleTypeName.MiniBus, Color = "Black", ParkingLotNo = "B1", VehicleLength = 2990, ParkingStartTime = DateTime.Now, NoOfTyres = 4, Model = "V6", Fabricate = "Volvo" },
                new Vehicle { Id = 12, RegNr = "QQK 443", VehicleTypeName = VehicleTypeName.Motorcycle, Color = "Blue", ParkingLotNo = "B2", VehicleLength = 7876,  ParkingStartTime = DateTime.Now, NoOfTyres = 2, Model = "V6", Fabricate = "Honda" },
                new Vehicle { Id = 13, RegNr = "QPG 454", VehicleTypeName = VehicleTypeName.Kombi, Color = "Pink", ParkingLotNo = "B3", VehicleLength = 3790,  ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Mazda" },
                new Vehicle { Id = 14, RegNr = "QFK 466", VehicleTypeName = VehicleTypeName.Sedan, Color = "Red", ParkingLotNo = "B4", VehicleLength = 2874, ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Nissan" },
                new Vehicle { Id = 15, RegNr = "QPJ 748", VehicleTypeName = VehicleTypeName.Vagen, Color = "White", ParkingLotNo = "B5", VehicleLength = 4765,  ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "BMW" },
                new Vehicle { Id = 16, RegNr = "QWK 844", VehicleTypeName = VehicleTypeName.Pickup, Color = "Silver", ParkingLotNo = "B6", VehicleLength = 6743, ParkingStartTime = DateTime.Now, NoOfTyres = 4, Model = "V6", Fabricate = "Scania" },
                new Vehicle { Id = 17, RegNr = "QTA 434", VehicleTypeName = VehicleTypeName.MiniBus, Color = "Black", ParkingLotNo = "B7", VehicleLength = 2990, ParkingStartTime = DateTime.Now, NoOfTyres = 4, Model = "V6", Fabricate = "Volvo" },
                new Vehicle { Id = 18, RegNr = "QQK 443", VehicleTypeName = VehicleTypeName.Motorcycle, Color = "Blue", ParkingLotNo = "B8", VehicleLength = 7876,  ParkingStartTime = DateTime.Now, NoOfTyres = 2, Model = "V6", Fabricate = "Honda" },
                new Vehicle { Id = 19, RegNr = "QPG 454", VehicleTypeName = VehicleTypeName.Kombi, Color = "Pink", ParkingLotNo = "B9", VehicleLength = 3790,  ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Mazda" },
                new Vehicle { Id = 20, RegNr = "QFK 466", VehicleTypeName = VehicleTypeName.Sedan, Color = "Red", ParkingLotNo = "B10", VehicleLength = 2874, ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Nissan" },
                new Vehicle { Id = 21, RegNr = "WPA 434", VehicleTypeName = VehicleTypeName.MiniBus, Color = "Black", ParkingLotNo = "C1", VehicleLength = 2990, ParkingStartTime = DateTime.Now, NoOfTyres = 4, Model = "V6", Fabricate = "Volvo" },
                new Vehicle { Id = 22, RegNr = "WGT 443", VehicleTypeName = VehicleTypeName.Motorcycle, Color = "Blue", ParkingLotNo = "C2", VehicleLength = 7876,  ParkingStartTime = DateTime.Now, NoOfTyres = 2, Model = "V6", Fabricate = "Honda" },
                new Vehicle { Id = 23, RegNr = "WPG 454", VehicleTypeName = VehicleTypeName.Kombi, Color = "Pink", ParkingLotNo = "C3", VehicleLength = 3790,  ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Mazda" },
                new Vehicle { Id = 24, RegNr = "WFK 466", VehicleTypeName = VehicleTypeName.Sedan, Color = "Red", ParkingLotNo = "C4", VehicleLength = 2874, ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "Nissan" },
                new Vehicle { Id = 25, RegNr = "WPJ 748", VehicleTypeName = VehicleTypeName.Vagen, Color = "White", ParkingLotNo = "C5", VehicleLength = 4765,  ParkingStartTime = DateTime.Now,  NoOfTyres = 4, Model = "V6", Fabricate = "BMW" },
                new Vehicle { Id = 26, RegNr = "WWK 844", VehicleTypeName = VehicleTypeName.Pickup, Color = "Silver", ParkingLotNo = "C6", VehicleLength = 6743, ParkingStartTime = DateTime.Now, NoOfTyres = 4, Model = "V6", Fabricate = "Scania" },
                new Vehicle { Id = 27, RegNr = "WTA 434", VehicleTypeName = VehicleTypeName.MiniBus, Color = "Black", ParkingLotNo = "C7", VehicleLength = 2990, ParkingStartTime = DateTime.Now, NoOfTyres = 4, Model = "V6", Fabricate = "Volvo" },
                new Vehicle { Id = 28, RegNr = "WGK 443", VehicleTypeName = VehicleTypeName.Motorcycle, Color = "Blue", ParkingLotNo = "C8", VehicleLength = 7876,  ParkingStartTime = DateTime.Now, NoOfTyres = 2, Model = "V6", Fabricate = "Honda" },

            });
        }
    }
}

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
            AutomaticMigrationsEnabled = false;
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
                new Vehicle { Id = 1, RegNr = "PPA434", VehicleTypeName = "Car", Color = "Black", ParkingLotNo = "A1", VehicleLength = 2990, NumberOfSeats = 4, ParkingStartTime = DateTime.Parse("2017-02-07"), ParkingStopTime = DateTime.Parse("2017-02-08"), NoOfTyres = 4, Model = "V6", Fabricate = "Volvo" },
                new Vehicle { Id = 2, RegNr = "QGK443", VehicleTypeName = "Bus", Color = "Blue", ParkingLotNo = "A5", VehicleLength = 7876, NumberOfSeats = 8, ParkingStartTime = DateTime.Parse("2017-02-07"), ParkingStopTime = DateTime.Parse("2017-02-08"), NoOfTyres = 4, Model = "V6", Fabricate = "Scania" },
                new Vehicle { Id = 3, RegNr = "RPG454", VehicleTypeName = "Kombi", Color = "Pink", ParkingLotNo = "A7", VehicleLength = 3790, NumberOfSeats = 4, ParkingStartTime = DateTime.Parse("2017-02-07"), ParkingStopTime = DateTime.Parse("2017-02-08"), NoOfTyres = 4, Model = "V6", Fabricate = "Mazda" },
                new Vehicle { Id = 4, RegNr = "TFK466", VehicleTypeName = "Sedan", Color = "Red", ParkingLotNo = "A9", VehicleLength = 2874, NumberOfSeats = 4, ParkingStartTime = DateTime.Parse("2017-02-07"), ParkingStopTime = DateTime.Parse("2017-02-08"), NoOfTyres = 4, Model = "V6", Fabricate = "Nissan" },
                new Vehicle { Id = 5, RegNr = "MPJ748", VehicleTypeName = "Vagen", Color = "White", ParkingLotNo = "A3", VehicleLength = 4765, NumberOfSeats = 4, ParkingStartTime = DateTime.Parse("2017-02-07"), ParkingStopTime = DateTime.Parse("2017-02-08"), NoOfTyres = 4, Model = "V6", Fabricate = "BMW" },
                new Vehicle { Id = 6, RegNr = "ZWK844", VehicleTypeName = "Bus", Color = "Silver", ParkingLotNo = "A7", VehicleLength = 6743, NumberOfSeats = 8, ParkingStartTime = DateTime.Parse("2017-02-07"), ParkingStopTime = DateTime.Parse("2017-02-08"), NoOfTyres = 4, Model = "V6", Fabricate = "Scania" },

            });

        }
    }
}

namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNr = c.String(),
                        VehicleTypeName = c.String(),
                        Color = c.String(),
                        ParkingLotNo = c.String(),
                        VehicleLength = c.Int(nullable: false),
                        NumberOfSeats = c.Int(nullable: false),
                        ParkingStartTime = c.DateTime(nullable: false),
                        ParkingStopTime = c.DateTime(nullable: false),
                        NoOfTyres = c.Int(nullable: false),
                        Model = c.String(),
                        Fabricate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}

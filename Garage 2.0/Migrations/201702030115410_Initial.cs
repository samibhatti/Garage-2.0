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
                        RegNr = c.String(nullable: false),
                        VehicleTypeName = c.Int(nullable: false),
                        Color = c.String(maxLength: 20),
                        ParkingLotNo = c.String(nullable: false),
                        VehicleLength = c.Int(nullable: false),
                        ParkingStartTime = c.DateTime(nullable: false),
                        NoOfTyres = c.Int(nullable: false),
                        Model = c.String(maxLength: 50),
                        Fabricate = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}

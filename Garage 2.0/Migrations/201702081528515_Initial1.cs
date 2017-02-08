namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ParkingStopTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vehicles", "ParingStopTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "ParingStopTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vehicles", "ParkingStopTime");
        }
    }
}

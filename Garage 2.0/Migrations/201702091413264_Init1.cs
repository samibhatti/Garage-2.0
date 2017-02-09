namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "ParkingStopTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "ParkingStopTime", c => c.DateTime(nullable: false));
        }
    }
}

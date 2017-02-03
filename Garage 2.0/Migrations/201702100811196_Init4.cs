namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Color", c => c.String(maxLength: 20));
            AlterColumn("dbo.Vehicles", "ParkingLotNo", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(maxLength: 50));
            AlterColumn("dbo.Vehicles", "Fabricate", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Fabricate", c => c.String());
            AlterColumn("dbo.Vehicles", "Model", c => c.String());
            AlterColumn("dbo.Vehicles", "ParkingLotNo", c => c.String());
            AlterColumn("dbo.Vehicles", "Color", c => c.String());
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String());
        }
    }
}

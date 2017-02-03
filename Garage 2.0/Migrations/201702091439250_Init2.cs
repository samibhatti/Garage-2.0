namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "NumberOfSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "NumberOfSeats", c => c.Int(nullable: false));
        }
    }
}

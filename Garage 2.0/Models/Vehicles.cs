namespace Garage_2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vehicles
    {
        public int Id { get; set; }

        [Required]
        public string RegNr { get; set; }

        public int VehicleTypeName { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [Required]
        public string ParkingLotNo { get; set; }

        public int VehicleLength { get; set; }

        public DateTime ParkingStartTime { get; set; }

        public int NoOfTyres { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Fabricate { get; set; }
    }
}

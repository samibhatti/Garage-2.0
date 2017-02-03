using Garage_2._0.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3} [0-9]{3}$", ErrorMessage = "Need to be in format AAA 123")]
        [Remote("RegNr", "Validate", ErrorMessage = "Registration Number is alreay parked")]
        //[RegularExpression("^[A-Z]{3}\\d{3}$", ErrorMessage = "Requires 3 letter follow by 3 numbers")]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        [Required]
        public VehicleTypeName VehicleTypeName { get; set; }

        [StringLength(20)]
        [Display(Name = "Color")]
        public string Color { get; set; }

        //[Required]
        [Display(Name = "Parking lot number")]
        [Remote("checkParkingLotNr", "Validate", ErrorMessage = "Parkinglot taken")]
        public string ParkingLotNo { get; set; }

        public int VehicleLength { get; set; }

        [Required]
        public DateTime ParkingStartTime { get; set; }


        [Range(0, 4, ErrorMessage = "Tyres must be 2 or 4")]
        [Display(Name = "Number of tyres")]
        [Remote("checkNumberOfTyres", "Validate", ErrorMessage = "Invalid number of tyres")]
        public int NoOfTyres { get; set; }

        [Display(Name = "Fabricate model")]
        public string FabricateModel { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Fabricate")]
        public string Fabricate { get; set; }

        public List<string> Freeparking { get; set; }


        public Vehicle toEnity(VehicleCreateViewModel model)
        {
            Vehicle vehicle = new Vehicle
            {
                Id = model.Id,
                Color = model.Color,
                Fabricate = model.Fabricate,
                Model = model.FabricateModel,
                NoOfTyres = model.NoOfTyres,
                ParkingLotNo = model.ParkingLotNo,
                ParkingStartTime = model.ParkingStartTime,
                RegNr = model.RegNr,
                VehicleLength = model.VehicleLength,
                VehicleTypeName = model.VehicleTypeName
            };
            return vehicle;
            
        }

        public VehicleCreateViewModel toViewModel(Vehicle model)
        {
            VehicleCreateViewModel vehicle = new VehicleCreateViewModel
            {
                Id = model.Id,
                Color = model.Color,
                Fabricate = model.Fabricate,
                FabricateModel = model.Model,
                NoOfTyres = model.NoOfTyres,
                ParkingLotNo = model.ParkingLotNo,
                ParkingStartTime = model.ParkingStartTime,
                RegNr = model.RegNr,
                VehicleLength = model.VehicleLength,
                VehicleTypeName = model.VehicleTypeName
            };
            return vehicle;

        }
    }

}
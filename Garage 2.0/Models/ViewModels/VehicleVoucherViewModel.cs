using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage_2._0.Helpers;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleVoucherViewModel
    {
        public int id { get; set; }
        public int VoucherID { get; set;}
        public string RegNr { get; set; }
        public VehicleTypeName VehicleTypeName { get; set; }
        public string Color { get; set; }
        public string ParkingLotNo { get; set; }
        public int VehicleLength { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime ParkingStartTime { get; set; }
        public DateTime ParkingStopTime { get; set; }
        public int NoOfTyres { get; set; }
        public string Modell { get; set; }
        public string Brand { get; set; }
        public int PaymentAmount { get; set; }
        public string Duration { get; set; }
        public string MemberName { get; private set; }
        public int MemberId { get; private set; }

        public int voucherId()
        {
            var random = new Random();
            int voucherID = random.Next(1000, 20000);
            return voucherID;
        }

        public VehicleVoucherViewModel toViewModel(Vehicle vehicle, Member member)
        {
            VehicleVoucherViewModel model = new VehicleVoucherViewModel
            {
                VoucherID = voucherId(),
                MemberId = member.MemberId,
                MemberName = member.FullName,
                RegNr = vehicle.RegNr,
                VehicleTypeName = VehicleTypeName,
                Color = vehicle.Color,
                ParkingLotNo = vehicle.ParkingLotNumber,
                ParkingStartTime = vehicle.ParkingStartTime,
                ParkingStopTime = DateTime.Now,
                NoOfTyres = vehicle.NumberOfTyres,
                Modell = vehicle.Modell,
                Brand = vehicle.Brand,
                Duration = ParkingHelper.GetDuration(vehicle.ParkingStartTime),
                PaymentAmount = ParkingHelper.GetCost(vehicle.ParkingStartTime)
            };
            return model;
        }

    }
}

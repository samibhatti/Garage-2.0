﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleVoucherViewModel
    {
        public int id { get; set; }
        public int VoucherID { get; set;}
        public string RegNr { get; set; }
        public string VehicleTypeName { get; set; }
        public string Color { get; set; }
        public string ParkingLotNo { get; set; }
        public int VehicleLength { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime ParkingStartTime { get; set; }
        public DateTime ParkingStopTime { get; set; }
        public int NoOfTyres { get; set; }
        public string Model { get; set; }
        public string Fabricate { get; set; }
        public int PaymentAmount { get; set; }
        public string Duration { get; set; }

        public int voucherId()
        {
            var random = new Random();
            int voucherID = random.Next(1000, 20000);
            return voucherID;
        }

        public string duration(DateTime startTime)
        {
            int days = (DateTime.Now - startTime).Days;
            int hours = (DateTime.Now - startTime).Hours;
            int minuts = (DateTime.Now - startTime).Minutes;
            string duration = days + " Days " + hours + " Hours " + minuts + " Minuts";
            return duration;
        }

        public VehicleVoucherViewModel toViewModel(Vehicle vehicle)
        {
            VehicleVoucherViewModel model = new VehicleVoucherViewModel
            {
                id = vehicle.Id,
                VoucherID = voucherId(),
                RegNr = vehicle.RegNr,
                VehicleTypeName =VehicleTypeName,
                Color = vehicle.Color,
                ParkingLotNo = vehicle.ParkingLotNo,
                VehicleLength = vehicle.VehicleLength,
                ParkingStartTime = vehicle.ParkingStartTime,
                ParkingStopTime = DateTime.Now,
                NoOfTyres = vehicle.NoOfTyres,
                Model = vehicle.Model,
                Fabricate = vehicle.Fabricate,
                Duration = duration(vehicle.ParkingStartTime),
                PaymentAmount = paymentAmount(vehicle.ParkingStartTime)
            };
            return model;
        }

        public int paymentAmount(DateTime startTime)
        {
            int days = (DateTime.Now - startTime).Days;
            int hours = (DateTime.Now - startTime).Hours;
            int minuts = (DateTime.Now - startTime).Minutes;
            int amount = (days * 24 * 60) + (hours * 60) + (minuts * 1);
            return amount;
        }
    }
}

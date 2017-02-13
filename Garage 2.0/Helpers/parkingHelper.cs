using Garage_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._0.Helpers
{
    public static class parkingHelper
    {
        public static int numberOfLots = 30;
        public static int pricePerHour = 60;
        public static List<int> accptedTyres = new List<int>() { 2, 4 };

        public static string getDuration(DateTime startTime)
        {
            int days = (DateTime.Now - startTime).Days;
            int hours = (DateTime.Now - startTime).Hours;
            int minuts = (DateTime.Now - startTime).Minutes;
            string duration = days + " Days " + hours + " Hours " + minuts + " Minuts";
            return duration;
        }

        public static int getCost(DateTime startTime)
        {
            int days = (DateTime.Now - startTime).Days;
            int hours = (DateTime.Now - startTime).Hours;
            int minuts = (DateTime.Now - startTime).Minutes;
            int priceDay = 24 * pricePerHour;
            int minutsCost = 0;
            if(minuts != 0)
            {
                minutsCost = (pricePerHour / minuts);
            }
            int amount = ((24 * pricePerHour) * days) + (hours * pricePerHour) + minutsCost;
            return amount;
        }

        public static List<string> parkingLots = new List<string>()
        {
            "A1","A2","A3","A4","A5","A6","A7","A8","A9","A10",
            "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10",
            "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10"
        };

        public static List<string> getFreeParkingLots(List<Vehicle> vehicles)
        {
            List<string> freeParkings = parkingLots;
            foreach(var vehicle in vehicles)
            {
                if (freeParkings.Contains(vehicle.ParkingLotNo))
                    freeParkings.Remove(vehicle.ParkingLotNo);
            }
            return freeParkings;
        }

    }
}
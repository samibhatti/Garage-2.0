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

 

        public static List<string> getFreeParkingLots(List<Vehicle> vehicles)
        {
            List<string> freeParkings = new parkingsLots().parkingLots;
            foreach(var vehicle in vehicles)
            {
                if (freeParkings.Contains(vehicle.ParkingLotNo))
                    freeParkings.Remove(vehicle.ParkingLotNo);
            }
            return freeParkings;
        }

    }
}
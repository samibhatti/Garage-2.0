using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._0.Helpers
{
    public static class parkingHelper
    {
        public static int numberOfLots = 60;
        public static int pricePerHour = 60;

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
            int amount = (days * pricePerHour) + (hours * pricePerHour) + (minuts * pricePerHour);
            return amount;
        }
    }
}
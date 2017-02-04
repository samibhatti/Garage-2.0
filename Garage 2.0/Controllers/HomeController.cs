using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garage_2._0.Helpers;
using Garage_2._0.DAL;

namespace Garage_2._0.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        private Garage_2_5_Context db = new Garage_2_5_Context();
        private int count;

        public ActionResult Index()
        {
            count = ParkingHelper.GetFreeParkingLots(db.Vehicles.ToList()).Count();

            if (count == 0 ) {

                ViewBag.parkingStatus = "Full";
            } else
            {
                ViewBag.parkingStatus = count.ToString();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}
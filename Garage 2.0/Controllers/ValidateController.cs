using Garage_2._0.DAL;
using Garage_2._0.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage_2._0.Controllers
{
    public class ValidateController : Controller
    {
        private Garage_2_5_Context db = new Garage_2_5_Context();


        public JsonResult RegNr(string RegNr)
        {
            var check = db.Vehicles.Where(x => x.RegNr == RegNr).FirstOrDefault();
            if(check == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult checkParkingLotNr(string ParkingLotNo)
        {
            var check = db.Vehicles.Where(x => x.ParkingLotNumber == ParkingLotNo).FirstOrDefault();
            if (check == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult checkNumberOfTyres(int NoOfTyres)
        {
            bool check = ParkingHelper.acceptedTyres.Contains(NoOfTyres);
            if (check)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
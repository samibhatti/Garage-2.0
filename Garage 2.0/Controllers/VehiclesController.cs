using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage_2._0.DAL;
using Garage_2._0.Models;
using System.ComponentModel;
using Garage_2._0.Models.ViewModels;
using log4net;
using Garage_2._0.Helpers;

namespace Garage_2._0.Controllers
{
    public class VehiclesController : Controller
    {
        private Garage_2_5_Context db = new Garage_2_5_Context();
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(VehiclesController));

        // GET: Vehicles
        public ActionResult Index(string orderBy, string searchTerm)
        {
            IQueryable<Vehicle> query = db.Vehicles;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.SearchTerm = searchTerm;
                query = query.Where(x => x.VehicleType.Name.Contains(searchTerm) || x.RegNr.Contains(searchTerm) || x.Brand.Contains(searchTerm) || x.Model.Contains(searchTerm) || x.ParkingLotNumber.Contains(searchTerm));
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "regnr":
                        query = query.OrderBy(x => x.RegNr);
                        break;
                    case "brand":
                        query = query.OrderBy(x => x.Brand);
                        break;
                    case "model":
                        query = query.OrderBy(x => x.Model);
                        break;
                    case "parkinglotnumber":
                        query = query.OrderBy(x => x.ParkingLotNumber);
                        break;
                    case "VehicleTypeId":
                        query = query.OrderBy(x => x.VehicleTypeId);
                        break;
                    default:
                        query = query.OrderBy(x => x.ParkingStartTime);
                        break;
                }
            }

            List<VehicleIndexViewModel> indexViewModel = new List<VehicleIndexViewModel>();
            foreach (var item in query)
            {
                VehicleIndexViewModel elem = new VehicleIndexViewModel(item.Id, item.RegNr, item.VehicleType.Id, item.ParkingLotNumber,
                    item.ParkingStartTime, item.Model, item.Brand);
                indexViewModel.Add(elem);
            }

            log.Error(query + "Info message");
            return View(indexViewModel);
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        public ActionResult ParkingDetails(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            return PartialView(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            var vehicles = db.Vehicles.ToList();

            int count = ParkingHelper.GetFreeParkingLots(vehicles).Count();

            if (count == 0)
            {
                return RedirectToAction("Error");
            }

            var createViewModel = new VehicleCreateViewModel
            {
                FreeParking = ParkingHelper.GetFreeParkingLots(vehicles),
                VehicleTypeList = db.VehicleTypes.ToList(),
            };

            return View(createViewModel);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,ParkingLotNumber,RegNr,VehicleTypeId,Color,NumberOfTyres,Model,Brand")] VehicleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.ParkingStartTime = DateTime.Now;
                var vehicle = new Vehicle
                {
                    Id = model.Id,
                    MemberId = model.MemberId,
                    ParkingLotNumber = model.ParkingLotNumber,
                    RegNr = model.RegNr,
                    VehicleTypeId = model.VehicleType.Id,
                    Color = model.Color,
                    NumberOfTyres = model.NumberOfTyres,
                    Model = model.Model,
                    Brand = model.Brand,
                };

                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNr,VehicleTypeName,Color,ParkingLotNo,ParkingStartTime,Model,Fabricate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleDeleteViewModel vehicle = new VehicleDeleteViewModel();
            vehicle = vehicle.toViewModel(db.Vehicles.Find(id));
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Voucher(int id)
        {
            VehicleVoucherViewModel vehicle = new VehicleVoucherViewModel();
            vehicle = vehicle.toViewModel(db.Vehicles.Find(id));

            return View(vehicle);
        }

        public ActionResult Information()
        {
            VehicleInformationViewModel model = new VehicleInformationViewModel();
            var allVehicles = db.Vehicles.ToList();
            model.ParkingInfo = ParkingHelper.GetParkingLots(allVehicles);
            model.NumberOfTyres = allVehicles.Sum(x => x.NumberOfTyres);
            model.TotalVehicle = allVehicles.Count();

            foreach (var vehicle in allVehicles)
            {
                model.CostToThisMoment = model.CostToThisMoment + ParkingHelper.GetCost(vehicle.ParkingStartTime);
            }
            return View(model);
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Important Message!!!";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

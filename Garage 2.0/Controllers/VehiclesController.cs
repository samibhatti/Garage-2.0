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

namespace Garage_2._0.Controllers
{
    public class VehiclesController : Controller
    {
        private Garage_2_0_Context db = new Garage_2_0_Context();


        // GET: Vehicles
        public ActionResult Index(string orderBy, string searchTerm)
        {
            IQueryable<Vehicle> query = db.Vehicles;
            if(!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.SearchTerm = searchTerm;
                query = query.Where(x => x.RegNr == searchTerm || x.Fabricate == searchTerm || x.Model == searchTerm || x.ParkingLotNo == searchTerm);
            }
            if(!string.IsNullOrEmpty(orderBy))
            {
                switch(orderBy.ToLower())
                {
                    case "regnr":
                        query = query.OrderBy(x => x.RegNr);
                        break;

                    case "fabricate":
                        query = query.OrderBy(x => x.Fabricate);
                        break;

                    case "model":
                        query = query.OrderBy(x => x.Model);
                        break;

                    case "parkingLotNo":
                        query = query.OrderBy(x => x.ParkingLotNo);
                        break;

                    case "ParkingStartTime":
                        query = query.OrderBy(x => x.ParkingStartTime);
                        break;

                    //default:
                    //    query = query.OrderBy(x => x.ParkingStopTime);
                    //    break;
                }
            }

            VehicleIndexViewModel model = new VehicleIndexViewModel();
            model.Vehicles = model.toList(query.ToList());

            return View(model);
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

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNr,VehicleTypeName,Color,ParkingLotNo,VehicleLength,NumberOfSeats,NoOfTyres,Model,Fabricate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                
                vehicle.ParkingStartTime = DateTime.Now;
                //vehicle.ParkingStopTime = DateTime.Now;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
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
        public ActionResult Edit([Bind(Include = "Id,RegNr,VehicleTypeName,Color,ParkingLotNo,VehicleLength,NumberOfSeats,ParkingStartTime,ParingStopTime,NoOfTyres,Model,Fabricate")] Vehicle vehicle)
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

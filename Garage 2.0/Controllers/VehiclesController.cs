﻿using System;
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

namespace Garage_2._0.Controllers
{
    public class VehiclesController : Controller
    {
        private Garage_2_0_Context db = new Garage_2_0_Context();
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(VehiclesController));

        // GET: Vehicles
        public ActionResult Index(string orderBy, string searchTerm)
        {
            //log.Debug("Debug message");
            //log.Warn("Warn message");
            //log.Error("Error message");
            //log.Fatal("Fatal message");

            IQueryable<Vehicle> query = db.Vehicles;
            if(!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.SearchTerm = searchTerm;
                query = query.Where(x => x.RegNr.Contains(searchTerm) || x.Fabricate.Contains(searchTerm) || x.Model.Contains(searchTerm) || x.ParkingLotNo.Contains(searchTerm));
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

                    default:
                        query = query.OrderBy(x => x.ParkingStartTime);
                        break;
                }
               
            }
            

            VehicleIndexViewModel model = new VehicleIndexViewModel();
            model.Vehicles = model.toList(query.ToList());
            log.Error(query + "Info message");
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
        public ActionResult Create([Bind(Include = "RegNr,VehicleTypeName,Color,NoOfTyres,Model,Fabricate")]VehicleCreateViewModel model)
        {
            model.ParkingLotNo = "TEST123";
            if (ModelState.IsValid)
            {
                model.ParkingStartTime = DateTime.Now;
                VehicleCreateViewModel m = new VehicleCreateViewModel();
                var vehicle = m.toEnity(model);
                //vehicle.ParkingStopTime = DateTime.Now;
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
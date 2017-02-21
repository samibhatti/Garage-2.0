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
            IQueryable<Vehicle> query = db.Vehicles.Include(m => m.Member);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.SearchTerm = searchTerm;
                query = query.Where(x => x.Member.FirstName.Contains(searchTerm) || x.Member.LastName.Contains(searchTerm) || x.VehicleType.Name.Contains(searchTerm) || x.RegNr.Contains(searchTerm));
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "member id":
                        query = query.OrderBy(x => x.MemberId);
                        break;
                    case "owner":
                        query = query.OrderBy(x => x.Member.FirstName);
                        break;
                    case "regnr":
                        query = query.OrderBy(x => x.RegNr);
                        break;
                    case "brand":
                        query = query.OrderBy(x => x.Brand);
                        break;
                    case "model":
                        query = query.OrderBy(x => x.Modell);
                        break;
                    case "parkinglotnumber":
                        query = query.OrderBy(x => x.ParkingLotNumber);
                        break;
                    case "vehicletypeid":
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
                Member member = db.Members.Find(item.MemberId);
                if(member != null)
                {
                    VehicleIndexViewModel elem = new VehicleIndexViewModel
                    {
                        Id = item.Id,
                        RegNr = item.RegNr,
                        VehicleTypeId = item.VehicleType.Id,
                        VehicleTypeName = item.VehicleType.Name,
                        ParkingLotNumber = item.ParkingLotNumber,
                        ParkingStartTime = item.ParkingStartTime,
                        Modell = item.Modell,
                        Brand = item.Brand,
                        MemberId = item.MemberId,
                        MemberFullName = member.FullName,
                    };
                    indexViewModel.Add(elem);
                }
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

            var member = db.Members.Find(vehicle.MemberId);
            var detailViewModel = new VehicleDetailViewModel
            {
                Vehicle = vehicle,
                Member = member,
            };

            return View(detailViewModel);
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
                FreeParking = new SelectList(ParkingHelper.GetFreeParkingLots(vehicles)),
                VehicleTypeList = new SelectList(db.VehicleTypes.ToList(), "Id", "Name"),
                MemberList = new SelectList(db.Members.ToList(), "MemberId","FullName"), //We dont really want to do this, but this is an experiment
            };

            return View(createViewModel);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // "MemberId,ParkingLotNumber,RegNr,VehicleTypeId,Color,NumberOfTyres,Model,Brand"
        public ActionResult Create([Bind(Include = "MemberId, ParkingLotNumber,RegNr,VehicleTypeId,Color,NumberOfTyres,VModel,Brand")] VehicleCreateViewModel model)
        {
                if (ModelState.IsValid)
                {
                    var vehicle = new Vehicle
                    {
                        Id = model.Id,
                        MemberId = model.MemberId,
                        ParkingLotNumber = model.ParkingLotNumber,
                        RegNr = model.RegNr,
                        VehicleTypeId = model.VehicleTypeId,
                        Color = model.Color,
                        NumberOfTyres = model.NumberOfTyres,
                        Modell = model.VModel,
                        Brand = model.Brand,
                        ParkingStartTime = DateTime.Now,
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

            var editViewModel = new VehicleEditViewModel
            {
                Vehicle = vehicle,
                VehicleTypeList = new SelectList(db.VehicleTypes.ToList(), "Id", "Name"),
            };

            return View(editViewModel);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,RegNr,VehicleTypeId,Color,ParkingLotNumber,Model,Brand")]*/ VehicleEditViewModel editModel)
        {
            var vehicle = editModel.Vehicle;
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
            VehicleVoucherViewModel voucherView = new VehicleVoucherViewModel();
            //vehicle = vehicle.toViewModel(db.Vehicles.Find(id));
            Vehicle vehicle = db.Vehicles.Find(id);
            Member member = db.Members.Find(id);
            voucherView = voucherView.toViewModel(vehicle, member);

            return View(voucherView);
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

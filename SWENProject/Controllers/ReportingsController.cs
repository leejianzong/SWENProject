using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWENProject.Models;

namespace SWENProject.Controllers
{
    public class ReportingsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Reportings
        public ActionResult Index()
        {
            return View(db.Reportings.ToList());
        }

        // GET: Reportings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporting reporting = db.Reportings.Find(id);
            if (reporting == null)
            {
                return HttpNotFound();
            }
            return View(reporting);
        }

        // GET: Reportings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reportings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportID,RoomStatus,AllOccupantsInARoom,AllGuestInAllTheRoom,RoomOccupancy,DutiesStaffAllocatedTo")] Reporting reporting)
        {
            if (ModelState.IsValid)
            {
                db.Reportings.Add(reporting);
                db.SaveChanges();
                return RedirectToAction("Reporting", "Home");
            }

            return View(reporting);
        }

        // GET: Reportings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporting reporting = db.Reportings.Find(id);
            if (reporting == null)
            {
                return HttpNotFound();
            }
            return View(reporting);
        }

        // POST: Reportings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportID,RoomStatus,AllOccupantsInARoom,AllGuestInAllTheRoom,RoomOccupancy,DutiesStaffAllocatedTo")] Reporting reporting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Reporting", "Home");
            }
            return View(reporting);
        }

        // GET: Reportings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporting reporting = db.Reportings.Find(id);
            if (reporting == null)
            {
                return HttpNotFound();
            }
            return View(reporting);
        }

        // POST: Reportings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Reporting reporting = db.Reportings.Find(id);
            db.Reportings.Remove(reporting);
            db.SaveChanges();
            return RedirectToAction("Reporting", "Home");
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

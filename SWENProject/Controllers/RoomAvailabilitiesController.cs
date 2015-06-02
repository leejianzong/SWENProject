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
    public class RoomAvailabilitiesController : Controller
    {
        private Model1 db = new Model1();

        // GET: RoomAvailabilities
        public ActionResult Index()
        {
            return View(db.RoomAvailabilities.ToList());
        }

        // GET: RoomAvailabilities/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomAvailability roomAvailability = db.RoomAvailabilities.Find(id);
            if (roomAvailability == null)
            {
                return HttpNotFound();
            }
            return View(roomAvailability);
        }

        // GET: RoomAvailabilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomAvailabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,RoomStatus,StaffIncharge,FirstName,LastName,CheckinDate,CheckoutDate,NumberOfAdult,NumberOfKid,ContactNumber,MailingAddress,EmailAddress,PaymentDetails,CreditCardNumber,CreditCardHolderName,CreditCardExpiryDate,AdditionalRemarks,LateCheck")] RoomAvailability roomAvailability)
        {
            if (ModelState.IsValid)
            {
                db.RoomAvailabilities.Add(roomAvailability);
                db.SaveChanges();
                return RedirectToAction("RoomAvailability", "Home");
            }

            return View(roomAvailability);
        }

        // GET: RoomAvailabilities/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomAvailability roomAvailability = db.RoomAvailabilities.Find(id);
            if (roomAvailability == null)
            {
                return HttpNotFound();
            }
            return View(roomAvailability);
        }

        // POST: RoomAvailabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,RoomStatus,StaffIncharge,FirstName,LastName,CheckinDate,CheckoutDate,NumberOfAdult,NumberOfKid,ContactNumber,MailingAddress,EmailAddress,PaymentDetails,CreditCardNumber,CreditCardHolderName,CreditCardExpiryDate,AdditionalRemarks,LateCheck")] RoomAvailability roomAvailability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomAvailability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RoomAvailability", "Home");
            }
            return View(roomAvailability);
        }

        // GET: RoomAvailabilities/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomAvailability roomAvailability = db.RoomAvailabilities.Find(id);
            if (roomAvailability == null)
            {
                return HttpNotFound();
            }
            return View(roomAvailability);
        }

        // POST: RoomAvailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RoomAvailability roomAvailability = db.RoomAvailabilities.Find(id);
            db.RoomAvailabilities.Remove(roomAvailability);
            db.SaveChanges();
            return RedirectToAction("RoomAvailability", "Home");
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

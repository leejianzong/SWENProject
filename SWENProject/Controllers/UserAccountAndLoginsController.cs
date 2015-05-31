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
    public class UserAccountAndLoginsController : Controller
    {
        private Model1 db = new Model1();

        // GET: UserAccountAndLogins
        public ActionResult Index()
        {
            return View(db.UserAccountAndLogins.ToList());
        }

        // GET: UserAccountAndLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccountAndLogin userAccountAndLogin = db.UserAccountAndLogins.Find(id);
            if (userAccountAndLogin == null)
            {
                return HttpNotFound();
            }
            return View(userAccountAndLogin);
        }

        // GET: UserAccountAndLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccountAndLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountID,UserName,Password,EmailAddress,FirstName,LastName,MailingAddress,ContactNumber")] UserAccountAndLogin userAccountAndLogin)
        {
            if (ModelState.IsValid)
            {
                db.UserAccountAndLogins.Add(userAccountAndLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccountAndLogin);
        }

        // GET: UserAccountAndLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccountAndLogin userAccountAndLogin = db.UserAccountAndLogins.Find(id);
            if (userAccountAndLogin == null)
            {
                return HttpNotFound();
            }
            return View(userAccountAndLogin);
        }

        // POST: UserAccountAndLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountID,UserName,Password,EmailAddress,FirstName,LastName,MailingAddress,ContactNumber")] UserAccountAndLogin userAccountAndLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccountAndLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccountAndLogin);
        }

        // GET: UserAccountAndLogins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccountAndLogin userAccountAndLogin = db.UserAccountAndLogins.Find(id);
            if (userAccountAndLogin == null)
            {
                return HttpNotFound();
            }
            return View(userAccountAndLogin);
        }

        // POST: UserAccountAndLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserAccountAndLogin userAccountAndLogin = db.UserAccountAndLogins.Find(id);
            db.UserAccountAndLogins.Remove(userAccountAndLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
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

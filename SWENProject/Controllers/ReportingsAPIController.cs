using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SWENProject.Models;

namespace SWENProject.Controllers
{
    public class ReportingsAPIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ReportingsAPI
        public IQueryable<Reporting> GetReportings()
        {
            return db.Reportings;
        }

        // GET: api/ReportingsAPI/5
        [ResponseType(typeof(Reporting))]
        public IHttpActionResult GetReporting(string id)
        {
            Reporting reporting = db.Reportings.Find(id);
            if (reporting == null)
            {
                return NotFound();
            }

            return Ok(reporting);
        }

        // PUT: api/ReportingsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReporting(string id, Reporting reporting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reporting.ReportID)
            {
                return BadRequest();
            }

            db.Entry(reporting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReportingsAPI
        [ResponseType(typeof(Reporting))]
        public IHttpActionResult PostReporting(Reporting reporting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reportings.Add(reporting);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReportingExists(reporting.ReportID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reporting.ReportID }, reporting);
        }

        // DELETE: api/ReportingsAPI/5
        [ResponseType(typeof(Reporting))]
        public IHttpActionResult DeleteReporting(string id)
        {
            Reporting reporting = db.Reportings.Find(id);
            if (reporting == null)
            {
                return NotFound();
            }

            db.Reportings.Remove(reporting);
            db.SaveChanges();

            return Ok(reporting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportingExists(string id)
        {
            return db.Reportings.Count(e => e.ReportID == id) > 0;
        }
    }
}
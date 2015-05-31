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
    public class StaffManagementsAPIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/StaffManagementsAPI
        public IQueryable<StaffManagement> GetStaffManagements()
        {
            return db.StaffManagements;
        }

        // GET: api/StaffManagementsAPI/5
        [ResponseType(typeof(StaffManagement))]
        public IHttpActionResult GetStaffManagement(string id)
        {
            StaffManagement staffManagement = db.StaffManagements.Find(id);
            if (staffManagement == null)
            {
                return NotFound();
            }

            return Ok(staffManagement);
        }

        // PUT: api/StaffManagementsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStaffManagement(string id, StaffManagement staffManagement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffManagement.StaffID)
            {
                return BadRequest();
            }

            db.Entry(staffManagement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffManagementExists(id))
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

        // POST: api/StaffManagementsAPI
        [ResponseType(typeof(StaffManagement))]
        public IHttpActionResult PostStaffManagement(StaffManagement staffManagement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StaffManagements.Add(staffManagement);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StaffManagementExists(staffManagement.StaffID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = staffManagement.StaffID }, staffManagement);
        }

        // DELETE: api/StaffManagementsAPI/5
        [ResponseType(typeof(StaffManagement))]
        public IHttpActionResult DeleteStaffManagement(string id)
        {
            StaffManagement staffManagement = db.StaffManagements.Find(id);
            if (staffManagement == null)
            {
                return NotFound();
            }

            db.StaffManagements.Remove(staffManagement);
            db.SaveChanges();

            return Ok(staffManagement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffManagementExists(string id)
        {
            return db.StaffManagements.Count(e => e.StaffID == id) > 0;
        }
    }
}
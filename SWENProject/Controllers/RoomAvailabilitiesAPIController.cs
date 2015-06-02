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
    public class RoomAvailabilitiesAPIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/RoomAvailabilitiesAPI
        public IQueryable<RoomAvailability> GetRoomAvailabilities()
        {
            return db.RoomAvailabilities;
        }

        // GET: api/RoomAvailabilitiesAPI/5
        [ResponseType(typeof(RoomAvailability))]
        public IHttpActionResult GetRoomAvailability(string id)
        {
            RoomAvailability roomAvailability = db.RoomAvailabilities.Find(id);
            if (roomAvailability == null)
            {
                return NotFound();
            }

            return Ok(roomAvailability);
        }

        // PUT: api/RoomAvailabilitiesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoomAvailability(string id, RoomAvailability roomAvailability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomAvailability.BookingID)
            {
                return BadRequest();
            }

            db.Entry(roomAvailability).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomAvailabilityExists(id))
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

        // POST: api/RoomAvailabilitiesAPI
        [ResponseType(typeof(RoomAvailability))]
        public IHttpActionResult PostRoomAvailability(RoomAvailability roomAvailability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoomAvailabilities.Add(roomAvailability);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoomAvailabilityExists(roomAvailability.BookingID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = roomAvailability.BookingID }, roomAvailability);
        }

        // DELETE: api/RoomAvailabilitiesAPI/5
        [ResponseType(typeof(RoomAvailability))]
        public IHttpActionResult DeleteRoomAvailability(string id)
        {
            RoomAvailability roomAvailability = db.RoomAvailabilities.Find(id);
            if (roomAvailability == null)
            {
                return NotFound();
            }

            db.RoomAvailabilities.Remove(roomAvailability);
            db.SaveChanges();

            return Ok(roomAvailability);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomAvailabilityExists(string id)
        {
            return db.RoomAvailabilities.Count(e => e.BookingID == id) > 0;
        }
    }
}
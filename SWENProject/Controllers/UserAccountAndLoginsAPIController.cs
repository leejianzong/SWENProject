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
    public class UserAccountAndLoginsAPIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/UserAccountAndLoginsAPI
        public IQueryable<UserAccountAndLogin> GetUserAccountAndLogins()
        {
            return db.UserAccountAndLogins;
        }

        // GET: api/UserAccountAndLoginsAPI/5
        [ResponseType(typeof(UserAccountAndLogin))]
        public IHttpActionResult GetUserAccountAndLogin(int id)
        {
            UserAccountAndLogin userAccountAndLogin = db.UserAccountAndLogins.Find(id);
            if (userAccountAndLogin == null)
            {
                return NotFound();
            }

            return Ok(userAccountAndLogin);
        }

        // PUT: api/UserAccountAndLoginsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAccountAndLogin(int id, UserAccountAndLogin userAccountAndLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAccountAndLogin.AccountID)
            {
                return BadRequest();
            }

            db.Entry(userAccountAndLogin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountAndLoginExists(id))
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

        // POST: api/UserAccountAndLoginsAPI
        [ResponseType(typeof(UserAccountAndLogin))]
        public IHttpActionResult PostUserAccountAndLogin(UserAccountAndLogin userAccountAndLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserAccountAndLogins.Add(userAccountAndLogin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserAccountAndLoginExists(userAccountAndLogin.AccountID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userAccountAndLogin.AccountID }, userAccountAndLogin);
        }

        // DELETE: api/UserAccountAndLoginsAPI/5
        [ResponseType(typeof(UserAccountAndLogin))]
        public IHttpActionResult DeleteUserAccountAndLogin(int id)
        {
            UserAccountAndLogin userAccountAndLogin = db.UserAccountAndLogins.Find(id);
            if (userAccountAndLogin == null)
            {
                return NotFound();
            }

            db.UserAccountAndLogins.Remove(userAccountAndLogin);
            db.SaveChanges();

            return Ok(userAccountAndLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAccountAndLoginExists(int id)
        {
            return db.UserAccountAndLogins.Count(e => e.AccountID == id) > 0;
        }
    }
}
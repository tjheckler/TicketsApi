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
using Tickets.Data;
using Tickets.Models;

namespace Tickets.Controllers
{
    public class PrioritiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Priorities
        public IQueryable<Priority> GetPriorities()
        {
            return db.Priorities;
        }

        // GET: api/Priorities/5
        [ResponseType(typeof(Priority))]
        public IHttpActionResult GetPriority(int id)
        {
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return NotFound();
            }

            return Ok(priority);
        }

        // PUT: api/Priorities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPriority(int id, Priority priority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priority.PriorityId)
            {
                return BadRequest();
            }

            db.Entry(priority).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityExists(id))
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

        // POST: api/Priorities
        [ResponseType(typeof(Priority))]
        public IHttpActionResult PostPriority(Priority priority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Priorities.Add(priority);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = priority.PriorityId }, priority);
        }

        // DELETE: api/Priorities/5
        [ResponseType(typeof(Priority))]
        public IHttpActionResult DeletePriority(int id)
        {
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return NotFound();
            }

            db.Priorities.Remove(priority);
            db.SaveChanges();

            return Ok(priority);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PriorityExists(int id)
        {
            return db.Priorities.Count(e => e.PriorityId == id) > 0;
        }
    }
}
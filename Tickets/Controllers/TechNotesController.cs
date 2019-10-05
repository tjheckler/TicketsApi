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
    public class TechNotesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TechNotes
        public IQueryable<TechNote> GetTechNotes()
        {
            return db.TechNotes;
        }

        // GET: api/TechNotes/5
        [ResponseType(typeof(TechNote))]
        public IHttpActionResult GetTechNote(int id)
        {
            TechNote techNote = db.TechNotes.Find(id);
            if (techNote == null)
            {
                return NotFound();
            }

            return Ok(techNote);
        }

        // PUT: api/TechNotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTechNote(int id, TechNote techNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != techNote.TechNoteId)
            {
                return BadRequest();
            }

            db.Entry(techNote).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechNoteExists(id))
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

        // POST: api/TechNotes
        [ResponseType(typeof(TechNote))]
        public IHttpActionResult PostTechNote(TechNote techNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TechNotes.Add(techNote);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = techNote.TechNoteId }, techNote);
        }

        // DELETE: api/TechNotes/5
        [ResponseType(typeof(TechNote))]
        public IHttpActionResult DeleteTechNote(int id)
        {
            TechNote techNote = db.TechNotes.Find(id);
            if (techNote == null)
            {
                return NotFound();
            }

            db.TechNotes.Remove(techNote);
            db.SaveChanges();

            return Ok(techNote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TechNoteExists(int id)
        {
            return db.TechNotes.Count(e => e.TechNoteId == id) > 0;
        }
    }
}
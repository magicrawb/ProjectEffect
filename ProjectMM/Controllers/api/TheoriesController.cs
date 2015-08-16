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
using ProjectMM.Data;
using ProjectMM.Data.Models;

namespace ProjectMM.Controllers.api
{
    public class TheoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Theories
        public IQueryable<Theory> GetTheories()
        {
            return db.Theories;
        }

        // GET: api/Theories/5
        [ResponseType(typeof(Theory))]
        public IHttpActionResult GetTheory(int id)
        {
            Theory theory = db.Theories.Find(id);
            if (theory == null)
            {
                return NotFound();
            }

            return Ok(theory);
        }

        // PUT: api/Theories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTheory(int id, Theory theory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != theory.TheoryId)
            {
                return BadRequest();
            }

            db.Entry(theory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheoryExists(id))
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

        // POST: api/Theories
        [ResponseType(typeof(Theory))]
        public IHttpActionResult PostTheory(Theory theory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Theories.Add(theory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = theory.TheoryId }, theory);
        }

        // DELETE: api/Theories/5
        [ResponseType(typeof(Theory))]
        public IHttpActionResult DeleteTheory(int id)
        {
            Theory theory = db.Theories.Find(id);
            if (theory == null)
            {
                return NotFound();
            }

            db.Theories.Remove(theory);
            db.SaveChanges();

            return Ok(theory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TheoryExists(int id)
        {
            return db.Theories.Count(e => e.TheoryId == id) > 0;
        }
    }
}
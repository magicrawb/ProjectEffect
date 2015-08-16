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
    public class NewTricksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/NewTricks
        public IQueryable<NewTrick> GetNewTricks()
        {
            return db.NewTricks;
        }

        // GET: api/NewTricks/5
        [ResponseType(typeof(NewTrick))]
        public IHttpActionResult GetNewTrick(int id)
        {
            NewTrick newTrick = db.NewTricks.Find(id);
            if (newTrick == null)
            {
                return NotFound();
            }

            return Ok(newTrick);
        }

        // PUT: api/NewTricks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewTrick(int id, NewTrick newTrick)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newTrick.NewTrickId)
            {
                return BadRequest();
            }

            db.Entry(newTrick).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewTrickExists(id))
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

        // POST: api/NewTricks
        [ResponseType(typeof(NewTrick))]
        public IHttpActionResult PostNewTrick(NewTrick newTrick)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewTricks.Add(newTrick);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newTrick.NewTrickId }, newTrick);
        }

        // DELETE: api/NewTricks/5
        [ResponseType(typeof(NewTrick))]
        public IHttpActionResult DeleteNewTrick(int id)
        {
            NewTrick newTrick = db.NewTricks.Find(id);
            if (newTrick == null)
            {
                return NotFound();
            }

            db.NewTricks.Remove(newTrick);
            db.SaveChanges();

            return Ok(newTrick);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewTrickExists(int id)
        {
            return db.NewTricks.Count(e => e.NewTrickId == id) > 0;
        }
    }
}
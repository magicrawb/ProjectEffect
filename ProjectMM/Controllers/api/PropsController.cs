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
    public class PropsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Props
        public IQueryable<Prop> GetProps()
        {
            return db.Props;
        }

        // GET: api/Props/5
        [ResponseType(typeof(Prop))]
        public IHttpActionResult GetProp(int id)
        {
            Prop prop = db.Props.Find(id);
            if (prop == null)
            {
                return NotFound();
            }

            return Ok(prop);
        }

        // PUT: api/Props/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProp(int id, Prop prop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prop.PropId)
            {
                return BadRequest();
            }

            db.Entry(prop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropExists(id))
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

        // POST: api/Props
        [ResponseType(typeof(Prop))]
        public IHttpActionResult PostProp(Prop prop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Props.Add(prop);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prop.PropId }, prop);
        }

        // DELETE: api/Props/5
        [ResponseType(typeof(Prop))]
        public IHttpActionResult DeleteProp(int id)
        {
            Prop prop = db.Props.Find(id);
            if (prop == null)
            {
                return NotFound();
            }

            db.Props.Remove(prop);
            db.SaveChanges();

            return Ok(prop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropExists(int id)
        {
            return db.Props.Count(e => e.PropId == id) > 0;
        }
    }
}
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
using Entities.Bodies;
using MyDatabase;

namespace SpacePro.Controllers.ApiControllers.ApiBodiesControllers
{
    public class MoonsController : ApiController
    {
        private ApplicationDbContext db;
        public MoonsController()
        {
            db = new ApplicationDbContext();
        }

        // GET: api/Moons
        public IQueryable<Moon> GetMoons()
        {
            return db.Moons;
        }

        // GET: api/Moons/5
        [ResponseType(typeof(Moon))]
        public IHttpActionResult GetMoon(int id)
        {
            Moon moon = db.Moons.Find(id);
            if (moon == null)
            {
                return NotFound();
            }

            return Ok(moon);
        }

        // PUT: api/Moons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMoon(int id, Moon moon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moon.MoonId)
            {
                return BadRequest();
            }

            db.Entry(moon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoonExists(id))
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

        // POST: api/Moons
        [ResponseType(typeof(Moon))]
        public IHttpActionResult PostMoon(Moon moon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Moons.Add(moon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = moon.MoonId }, moon);
        }

        // DELETE: api/Moons/5
        [ResponseType(typeof(Moon))]
        public IHttpActionResult DeleteMoon(int id)
        {
            Moon moon = db.Moons.Find(id);
            if (moon == null)
            {
                return NotFound();
            }

            db.Moons.Remove(moon);
            db.SaveChanges();

            return Ok(moon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MoonExists(int id)
        {
            return db.Moons.Count(e => e.MoonId == id) > 0;
        }
    }
}
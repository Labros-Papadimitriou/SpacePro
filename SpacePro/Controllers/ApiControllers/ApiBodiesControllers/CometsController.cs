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
    public class CometsController : ApiController
    {
        private ApplicationDbContext db;
        public CometsController()
        {
            db = new ApplicationDbContext();
        }

        // GET: api/Comets
        public IQueryable<Comet> GetComets()
        {
            return db.Comets;
        }

        // GET: api/Comets/5
        [ResponseType(typeof(Comet))]
        public IHttpActionResult GetComet(int id)
        {
            Comet comet = db.Comets.Find(id);
            if (comet == null)
            {
                return NotFound();
            }

            return Ok(comet);
        }

        // PUT: api/Comets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComet(int id, Comet comet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comet.CometId)
            {
                return BadRequest();
            }

            db.Entry(comet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CometExists(id))
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

        // POST: api/Comets
        [ResponseType(typeof(Comet))]
        public IHttpActionResult PostComet(Comet comet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comets.Add(comet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comet.CometId }, comet);
        }

        // DELETE: api/Comets/5
        [ResponseType(typeof(Comet))]
        public IHttpActionResult DeleteComet(int id)
        {
            Comet comet = db.Comets.Find(id);
            if (comet == null)
            {
                return NotFound();
            }

            db.Comets.Remove(comet);
            db.SaveChanges();

            return Ok(comet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CometExists(int id)
        {
            return db.Comets.Count(e => e.CometId == id) > 0;
        }
    }
}
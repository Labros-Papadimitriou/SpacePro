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
    public class StarsController : ApiController
    {
        private ApplicationDbContext db;
        public StarsController()
        {
            db = new ApplicationDbContext();
        }

        // GET: api/Stars
        public IQueryable<Star> GetStars()
        {
            return db.Stars;
        }

        // GET: api/Stars/5
        [ResponseType(typeof(Star))]
        public IHttpActionResult GetStar(int id)
        {
            Star star = db.Stars.Find(id);
            if (star == null)
            {
                return NotFound();
            }

            return Ok(star);
        }

        // PUT: api/Stars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStar(int id, Star star)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != star.StarId)
            {
                return BadRequest();
            }

            db.Entry(star).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarExists(id))
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

        // POST: api/Stars
        [ResponseType(typeof(Star))]
        public IHttpActionResult PostStar(Star star)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stars.Add(star);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = star.StarId }, star);
        }

        // DELETE: api/Stars/5
        [ResponseType(typeof(Star))]
        public IHttpActionResult DeleteStar(int id)
        {
            Star star = db.Stars.Find(id);
            if (star == null)
            {
                return NotFound();
            }

            db.Stars.Remove(star);
            db.SaveChanges();

            return Ok(star);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StarExists(int id)
        {
            return db.Stars.Count(e => e.StarId == id) > 0;
        }
    }
}
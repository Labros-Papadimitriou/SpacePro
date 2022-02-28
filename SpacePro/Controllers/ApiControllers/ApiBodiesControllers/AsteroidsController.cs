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
    public class AsteroidsController : ApiController
    {
        private ApplicationDbContext db;
        public AsteroidsController()
        {
            db = new ApplicationDbContext();
        }

        // GET: api/Asteroids
        public IQueryable<Asteroid> GetAsteroids()
        {
            return db.Asteroids;
        }

        // GET: api/Asteroids/5
        [ResponseType(typeof(Asteroid))]
        public IHttpActionResult GetAsteroid(int id)
        {
            Asteroid asteroid = db.Asteroids.Find(id);
            if (asteroid == null)
            {
                return NotFound();
            }

            return Ok(asteroid);
        }

        // PUT: api/Asteroids/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsteroid(int id, Asteroid asteroid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asteroid.AsteroidId)
            {
                return BadRequest();
            }

            db.Entry(asteroid).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsteroidExists(id))
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

        // POST: api/Asteroids
        [ResponseType(typeof(Asteroid))]
        public IHttpActionResult PostAsteroid(Asteroid asteroid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asteroids.Add(asteroid);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asteroid.AsteroidId }, asteroid);
        }

        // DELETE: api/Asteroids/5
        [ResponseType(typeof(Asteroid))]
        public IHttpActionResult DeleteAsteroid(int id)
        {
            Asteroid asteroid = db.Asteroids.Find(id);
            if (asteroid == null)
            {
                return NotFound();
            }

            db.Asteroids.Remove(asteroid);
            db.SaveChanges();

            return Ok(asteroid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsteroidExists(int id)
        {
            return db.Asteroids.Count(e => e.AsteroidId == id) > 0;
        }
    }
}
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
    public class PlanetsController : ApiController
    {
        private ApplicationDbContext db;
        public PlanetsController()
        {
            db = new ApplicationDbContext();
        }

        // GET: api/Planets
        public IQueryable<Planet> GetPlanets()
        {
            return db.Planets;
        }

        // GET: api/Planets/5
        [ResponseType(typeof(Planet))]
        public IHttpActionResult GetPlanet(int id)
        {
            Planet planet = db.Planets.Find(id);
            if (planet == null)
            {
                return NotFound();
            }

            return Ok(planet);
        }

        // PUT: api/Planets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlanet(int id, Planet planet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planet.PlanetId)
            {
                return BadRequest();
            }

            db.Entry(planet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetExists(id))
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

        // POST: api/Planets
        [ResponseType(typeof(Planet))]
        public IHttpActionResult PostPlanet(Planet planet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Planets.Add(planet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = planet.PlanetId }, planet);
        }

        // DELETE: api/Planets/5
        [ResponseType(typeof(Planet))]
        public IHttpActionResult DeletePlanet(int id)
        {
            Planet planet = db.Planets.Find(id);
            if (planet == null)
            {
                return NotFound();
            }

            db.Planets.Remove(planet);
            db.SaveChanges();

            return Ok(planet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlanetExists(int id)
        {
            return db.Planets.Count(e => e.PlanetId == id) > 0;
        }
    }
}
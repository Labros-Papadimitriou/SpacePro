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
using Persistance_UnitOfWork;

namespace SpaceRestApi.Controllers.ApiBodiesControllers
{
    public class PlanetsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlanetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Planets
        public IEnumerable<Planet> GetPlanets()
        {
            return _unitOfWork.Planets.GetAll();
        }

        // GET: api/Planets/5
        [ResponseType(typeof(Planet))]
        public IHttpActionResult GetPlanet(int id)
        {
            Planet planet = _unitOfWork.Planets.Get(id);
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

            _unitOfWork.Planets.ModifyEntity(planet);

            try
            {
                _unitOfWork.Complete();
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

            _unitOfWork.Planets.Add(planet);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = planet.PlanetId }, planet);
        }

        // DELETE: api/Planets/5
        [ResponseType(typeof(Planet))]
        public IHttpActionResult DeletePlanet(int id)
        {
            Planet planet = _unitOfWork.Planets.Get(id);
            if (planet == null)
            {
                return NotFound();
            }

            _unitOfWork.Planets.Remove(planet);
            _unitOfWork.Complete();

            return Ok(planet);
        }
        private bool PlanetExists(int id)
        {
            return _unitOfWork.Planets.GetAll().Count(e => e.PlanetId == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
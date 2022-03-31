using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<Planet>> GetPlanets()
        {
            return await _unitOfWork.Planets.GetAll();
        }

        // GET: api/Planets/5
        [ResponseType(typeof(Planet))]
        public async Task<IHttpActionResult> GetPlanet(int id)
        {
            Planet planet = await _unitOfWork.Planets.Get(id);
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
                return NotFound();
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
        public async Task<IHttpActionResult> DeletePlanet(int id)
        {
            Planet planet = await _unitOfWork.Planets.Get(id);
            if (planet == null)
            {
                return NotFound();
            }

            _unitOfWork.Planets.Remove(planet);
            await _unitOfWork.Complete();

            return Ok(planet);
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
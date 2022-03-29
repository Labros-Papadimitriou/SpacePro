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
    public class AsteroidsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public AsteroidsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Asteroids
        public IEnumerable<Asteroid> GetAsteroids()
        {
            return _unitOfWork.Asteroids.GetAll();
        }

        // GET: api/Asteroids/5
        [ResponseType(typeof(Asteroid))]
        public IHttpActionResult GetAsteroid(int id)
        {
            Asteroid asteroid = _unitOfWork.Asteroids.Get(id);
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

            _unitOfWork.Asteroids.ModifyEntity(asteroid);

            try
            {
                _unitOfWork.Complete();
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

            _unitOfWork.Asteroids.Add(asteroid);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = asteroid.AsteroidId }, asteroid);
        }

        // DELETE: api/Asteroids/5
        [ResponseType(typeof(Asteroid))]
        public IHttpActionResult DeleteAsteroid(int id)
        {
            Asteroid asteroid = _unitOfWork.Asteroids.Get(id);
            if (asteroid == null)
            {
                return NotFound();
            }

            _unitOfWork.Asteroids.Remove(asteroid);
            _unitOfWork.Complete();

            return Ok(asteroid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsteroidExists(int id)
        {
            return _unitOfWork.Asteroids.GetAll().Count(e => e.AsteroidId == id) > 0;
        }
    }
}
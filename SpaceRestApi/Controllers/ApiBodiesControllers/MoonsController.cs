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
    public class MoonsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public MoonsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Moons
        public IEnumerable<Moon> GetMoons()
        {
            return _unitOfWork.Moons.GetAll();
        }

        // GET: api/Moons/5
        [ResponseType(typeof(Moon))]
        public IHttpActionResult GetMoon(int id)
        {
            Moon moon = _unitOfWork.Moons.Get(id);
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

            _unitOfWork.Moons.ModifyEntity(moon);

            try
            {
                _unitOfWork.Complete();
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

            _unitOfWork.Moons.Add(moon);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = moon.MoonId }, moon);
        }

        // DELETE: api/Moons/5
        [ResponseType(typeof(Moon))]
        public IHttpActionResult DeleteMoon(int id)
        {
            Moon moon = _unitOfWork.Moons.Get(id);
            if (moon == null)
            {
                return NotFound();
            }

            _unitOfWork.Moons.Remove(moon);
            _unitOfWork.Complete();

            return Ok(moon);
        }
        private bool MoonExists(int id)
        {
            return _unitOfWork.Moons.GetAll().Count(e => e.MoonId == id) > 0;
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
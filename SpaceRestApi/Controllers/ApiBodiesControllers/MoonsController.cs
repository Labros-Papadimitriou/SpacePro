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
    public class MoonsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public MoonsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Moons
        public async Task<IEnumerable<Moon>> GetMoons()
        {
            return await _unitOfWork.Moons.GetAll();
        }

        // GET: api/Moons/5
        [ResponseType(typeof(Moon))]
        public async Task<IHttpActionResult> GetMoon(int id)
        {
            Moon moon = await _unitOfWork.Moons.Get(id);
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
                return NotFound();
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
        public async Task<IHttpActionResult> DeleteMoon(int id)
        {
            Moon moon = await _unitOfWork.Moons.Get(id);
            if (moon == null)
            {
                return NotFound();
            }

            _unitOfWork.Moons.Remove(moon);
            await _unitOfWork.Complete();

            return Ok(moon);
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
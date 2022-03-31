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
    public class CometsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CometsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Comets
        public async Task<IEnumerable<Comet>> GetComets()
        {
            return await _unitOfWork.Comets.GetAll();
        }

        // GET: api/Comets/5
        [ResponseType(typeof(Comet))]
        public async Task<IHttpActionResult> GetComet(int id)
        {
            Comet comet = await _unitOfWork.Comets.Get(id);
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

            _unitOfWork.Comets.ModifyEntity(comet);

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

        // POST: api/Comets
        [ResponseType(typeof(Comet))]
        public IHttpActionResult PostComet(Comet comet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Comets.Add(comet);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = comet.CometId }, comet);
        }

        // DELETE: api/Comets/5
        [ResponseType(typeof(Comet))]
        public async Task<IHttpActionResult> DeleteComet(int id)
        {
            Comet comet = await _unitOfWork.Comets.Get(id);
            if (comet == null)
            {
                return NotFound();
            }

            _unitOfWork.Comets.Remove(comet);
            await _unitOfWork.Complete();

            return Ok(comet);
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
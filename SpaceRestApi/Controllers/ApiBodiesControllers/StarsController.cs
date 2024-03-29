﻿using System;
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
    public class StarsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public StarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Stars
        public async Task<IEnumerable<Star>> GetStars()
        {
            return await _unitOfWork.Stars.GetAll();
        }

        // GET: api/Stars/5
        [ResponseType(typeof(Star))]
        public async Task<IHttpActionResult> GetStar(int id)
        {
            Star star = await _unitOfWork.Stars.Get(id);
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

            _unitOfWork.Stars.ModifyEntity(star);

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

        // POST: api/Stars
        [ResponseType(typeof(Star))]
        public IHttpActionResult PostStar(Star star)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Stars.Add(star);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = star.StarId }, star);
        }

        // DELETE: api/Stars/5
        [ResponseType(typeof(Star))]
        public async Task<IHttpActionResult> DeleteStar(int id)
        {
            Star star = await _unitOfWork.Stars.Get(id);
            if (star == null)
            {
                return NotFound();
            }

            _unitOfWork.Stars.Remove(star);
            await _unitOfWork.Complete();

            return Ok(star);
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
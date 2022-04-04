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

namespace SpaceRestApi.Controllers
{
    public class BodyImageController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BodyImageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/BodyImage
        public async Task<IEnumerable<BodyImage>> GetBodyImages()
        {
            return await _unitOfWork.BodyImages.GetAll();
        }

        //// GET: api/BodyImage/5
        //[ResponseType(typeof(BodyImage))]
        //public async Task<IHttpActionResult> GetBodyImage(int id)
        //{
        //    BodyImage bodyImage = await db.BodyImages.FindAsync(id);
        //    if (bodyImage == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(bodyImage);
        //}

        //// PUT: api/BodyImage/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutBodyImage(int id, BodyImage bodyImage)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != bodyImage.BodyImageId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(bodyImage).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BodyImageExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/BodyImage
        //[ResponseType(typeof(BodyImage))]
        //public async Task<IHttpActionResult> PostBodyImage(BodyImage bodyImage)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.BodyImages.Add(bodyImage);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = bodyImage.BodyImageId }, bodyImage);
        //}

        //// DELETE: api/BodyImage/5
        //[ResponseType(typeof(BodyImage))]
        //public async Task<IHttpActionResult> DeleteBodyImage(int id)
        //{
        //    BodyImage bodyImage = await db.BodyImages.FindAsync(id);
        //    if (bodyImage == null)
        //    {
        //        return NotFound();
        //    }

        //    db.BodyImages.Remove(bodyImage);
        //    await db.SaveChangesAsync();

        //    return Ok(bodyImage);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool BodyImageExists(int id)
        //{
        //    return db.BodyImages.Count(e => e.BodyImageId == id) > 0;
        //}
    }
}
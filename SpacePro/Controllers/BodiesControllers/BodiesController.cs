using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpacePro.Controllers.HelperClasses;
using System.Threading.Tasks;

namespace SpacePro.Controllers.BodiesControllers
{
    public class BodiesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BodiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult BodiesTable()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetBodies()
        {
            List<object> bodies = new List<object>();
            var moons = (await _unitOfWork.Moons.GetAll()).TransformListOfMoonsToListOfObjects();
            bodies.AddRange(moons);
            var planets = (await _unitOfWork.Planets.GetAll()).TransformListOfPlanetsToListOfObjects();
            bodies.AddRange(planets);
            var asteroids = (await _unitOfWork.Asteroids.GetAll()).TransformListOfAsteroidsToListOfObjects();
            bodies.AddRange(asteroids);
            var comets = (await _unitOfWork.Comets.GetAll()).TransformListOfCometsToListOfObjects();
            bodies.AddRange(comets);
            var stars = (await _unitOfWork.Stars.GetAll()).TransformListOfStarsToListOfObjects();
            bodies.AddRange(stars);
            return Json(new { data = bodies }, JsonRequestBehavior.AllowGet);
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
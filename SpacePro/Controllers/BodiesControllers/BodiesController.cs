using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpacePro.Controllers.HelperClasses;

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
        public ActionResult GetBodies()
        {
            List<object> bodies = new List<object>();
            var moons = _unitOfWork.Moons.GetAll().TransformListOfMoonsToListOfObjects();
            bodies.AddRange(moons);
            var planets = _unitOfWork.Planets.GetAll().TransformListOfPlanetsToListOfObjects();
            bodies.AddRange(planets);
            var asteroids = _unitOfWork.Asteroids.GetAll().TransformListOfAsteroidsToListOfObjects();
            bodies.AddRange(asteroids);
            var comets = _unitOfWork.Comets.GetAll().TransformListOfCometsToListOfObjects();
            bodies.AddRange(comets);
            var stars = _unitOfWork.Stars.GetAll().TransformListOfStarsToListOfObjects();
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
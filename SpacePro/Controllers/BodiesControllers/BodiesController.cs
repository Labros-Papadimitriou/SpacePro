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
       readonly UnitOfWork unitOfWork;
        public BodiesController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        // GET: Bodies
        public ActionResult BodiesTable()
        {
            return View();
        }
        public ActionResult GetBodies()
        {
            List<object> bodies = new List<object>();
            var moons = unitOfWork.Moons.GetAll().TransformListOfMoonsToListOfObjects();
            bodies.AddRange(moons);
            var planets = unitOfWork.Planets.GetAll().TransformListOfPlanetsToListOfObjects();
            bodies.AddRange(planets);
            var asteroids = unitOfWork.Asteroids.GetAll().TransformListOfAsteroidsToListOfObjects();
            bodies.AddRange(asteroids);
            var comets = unitOfWork.Comets.GetAll().TransformListOfCometsToListOfObjects();
            bodies.AddRange(comets);
            var stars = unitOfWork.Stars.GetAll().TransformListOfStarsToListOfObjects();
            bodies.AddRange(stars);
            return Json(new { data = bodies }, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
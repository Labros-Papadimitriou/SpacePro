using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BodiesControllers
{
    public class BodiesController : Controller
    {
        ApplicationDbContext db;
        public BodiesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Bodies
        public ActionResult BodiesTable()
        {
            return View();
        }
        public ActionResult GetBodies()
        {
            List<object> bodies = new List<object>();
            var moons = db.Moons.Select(m => new
            {
                Id = m.MoonId,
                Name = m.Name,
                VolValue = m.VolValue,
                MassValue = m.MassValue,
                Dimension = m.Dimension,
                DiscoveredBy = m.DiscoveredBy,
                DiscoveryDate = m.DiscoveryDate,
                BodyType= "Moon"
            });
            bodies.AddRange(moons);
            var planets = db.Planets.Select(p => new
            {
                Id = p.PlanetId,
                Name = p.Name,
                VolValue = p.VolValue,
                MassValue = p.MassValue,
                Dimension = p.Dimension,
                DiscoveredBy = p.DiscoveredBy,
                DiscoveryDate = p.DiscoveryDate,
                BodyType = "Planet"
            });
            bodies.AddRange(planets);
            var asteroids = db.Asteroids.Select(a => new
            {
                Id = a.AsteroidId,
                Name = a.Name,
                VolValue = a.VolValue,
                MassValue = a.MassValue,
                Dimension = a.Dimension,
                DiscoveredBy = a.DiscoveredBy,
                DiscoveryDate = a.DiscoveryDate,
                BodyType = "Asteroid"
            });
            bodies.AddRange(asteroids);
            var comets = db.Comets.Select(c => new
            {
                Id = c.CometId,
                Name = c.Name,
                VolValue = c.VolValue,
                MassValue = c.MassValue,
                Dimension = c.Dimension,
                DiscoveredBy = c.DiscoveredBy,
                DiscoveryDate = c.DiscoveryDate,
                BodyType = "Comet"
            });
            bodies.AddRange(comets);
            var stars = db.Stars.Select(s => new
            {
                Id = s.StarId,
                Name = s.Name,
                VolValue = s.VolValue,
                MassValue = s.MassValue,
                Dimension = s.Dimension,
                DiscoveredBy = s.DiscoveredBy,
                DiscoveryDate = s.DiscoveryDate,
                BodyType = "Star"
            });
            bodies.AddRange(stars);
            return Json(new { data = bodies },JsonRequestBehavior.AllowGet);
        }
    }
}
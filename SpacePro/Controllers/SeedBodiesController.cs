using Entities.Bodies;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers
{
    public class SeedBodiesController : Controller
    {
        private readonly ApplicationDbContext db;
        public SeedBodiesController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void CreatePlanets(List<Planet> planets)
        {
            foreach (var planet in planets)
            {
                db.Entry(planet).State = EntityState.Added;
            }
            db.SaveChanges();
        }

        [HttpPost]
        public void CreateMoons(List<Moon> apiMoons)
        {
            var moons = apiMoons.Where(x => db.Planets.Any(p => x.aroundPlanet.ToLower() == p.Name.ToLower()));
            moons = moons.Select(x=>new Moon{ 
                Name = x.Name,
                MassValue=x.MassValue,
                VolValue=x.VolValue,
                DiscoveredBy = x.DiscoveredBy,
                DiscoveryDate=x.DiscoveryDate,
                PlanetId=db.Planets.FirstOrDefault(p=>p.Name.ToLower()==x.aroundPlanet.ToLower()).PlanetId
            });
            foreach (var moon in moons)
            {
                db.Entry(moon).State = EntityState.Added;
            }
            db.SaveChanges();
        }

        [HttpPost]
        public void CreateComets(List<Comet> comets)
        {
            foreach (var comet in comets)
            {
                db.Entry(comet).State = EntityState.Added;
            }
            db.SaveChanges();
        }

        [HttpPost]
        public void CreateAsteroids(List<Asteroid> asteroids)
        {
            foreach (var asteroid in asteroids)
            {
                db.Entry(asteroid).State = EntityState.Added;
            }
            db.SaveChanges();
        }

        [HttpPost]
        public void CreateStars(List<Star> stars)
        {
            foreach (var star in stars)
            {
                db.Entry(star).State = EntityState.Added;
            }
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
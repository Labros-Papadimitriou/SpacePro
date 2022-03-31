using Entities.Bodies;
using MyDatabase;
using Persistance_UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;
        public SeedBodiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void CreatePlanets(List<Planet> planets)
        {
            foreach (var planet in planets)
            {
                _unitOfWork.Planets.Add(planet);
            }
            _unitOfWork.Complete();
        }

        [HttpPost]
        public async void CreateMoons(List<Moon> apiMoons)
        {
            var allPlanets = await _unitOfWork.Planets.GetAll();
            var moons = apiMoons.Where(x => allPlanets.Any(p => x.aroundPlanet.ToLower() == p.Name.ToLower()));
            moons = (IEnumerable<Moon>)moons.Select(async x => new Moon
            {
                Name = x.Name,
                MassValue = x.MassValue,
                VolValue = x.VolValue,
                DiscoveredBy = x.DiscoveredBy,
                DiscoveryDate = x.DiscoveryDate,
                PlanetId = (await _unitOfWork.Planets.GetAll()).FirstOrDefault(p => p.Name.ToLower() == x.aroundPlanet.ToLower()).PlanetId
            });
            foreach (var moon in moons)
            {
                _unitOfWork.Moons.Add(moon);
            }
            await _unitOfWork.Complete();
        }

        [HttpPost]
        public void CreateComets(List<Comet> comets)
        {
            foreach (var comet in comets)
            {
                _unitOfWork.Comets.Add(comet);
            }
            _unitOfWork.Complete();
        }

        [HttpPost]
        public void CreateAsteroids(List<Asteroid> asteroids)
        {
            foreach (var asteroid in asteroids)
            {
                _unitOfWork.Asteroids.Add(asteroid);
            }
            _unitOfWork.Complete();
        }

        [HttpPost]
        public void CreateStars(List<Star> stars)
        {
            foreach (var star in stars)
            {
                _unitOfWork.Stars.Add(star);
            }
            _unitOfWork.Complete();
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
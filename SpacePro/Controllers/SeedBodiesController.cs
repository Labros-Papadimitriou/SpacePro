using Entities.Bodies;
using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task CreatePlanets(List<Planet> planets)
        {
            foreach (var planet in planets)
            {
                _unitOfWork.Planets.Add(planet);
            }
            await _unitOfWork.Complete();
        }

        [HttpPost]
        public async Task CreateMoons(List<Moon> apiMoons)
        {
            var allPlanets = await _unitOfWork.Planets.GetAll();
            var moons = apiMoons.Where(x => allPlanets.Any(p => x.aroundPlanet.ToLower() == p.Name.ToLower()));
            moons = moons.Select(x => new Moon
            {
                Name = x.Name,
                MassValue = x.MassValue,
                VolValue = x.VolValue,
                DiscoveredBy = x.DiscoveredBy,
                DiscoveryDate = x.DiscoveryDate,
                PlanetId = allPlanets.FirstOrDefault(p => p.Name.ToLower() == x.aroundPlanet.ToLower()).PlanetId
            });
            foreach (var moon in moons)
            {
                _unitOfWork.Moons.Add(moon);
            }
            await _unitOfWork.Complete();
        }

        [HttpPost]
        public async Task CreateComets(List<Comet> comets)
        {
            foreach (var comet in comets)
            {
                _unitOfWork.Comets.Add(comet);
            }
            await _unitOfWork.Complete();
        }

        [HttpPost]
        public async Task CreateAsteroids(List<Asteroid> asteroids)
        {
            foreach (var asteroid in asteroids)
            {
                _unitOfWork.Asteroids.Add(asteroid);
            }
            await _unitOfWork.Complete();
        }

        [HttpPost]
        public async Task CreateStars(List<Star> stars)
        {
            foreach (var star in stars)
            {
                _unitOfWork.Stars.Add(star);
            }
            await _unitOfWork.Complete();
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
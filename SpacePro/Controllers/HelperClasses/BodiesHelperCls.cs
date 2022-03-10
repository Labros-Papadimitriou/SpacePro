using Entities.Bodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacePro.Controllers.HelperClasses
{
    public static class BodiesHelperCls
    {
        public static IEnumerable<object> TransformListOfMoonsToListOfObjects(this IEnumerable<Moon> moons)
        {
            return moons.Select(m => new
            {
                Id = m.MoonId,
                m.Name,
                m.VolValue,
                m.MassValue,
                m.Dimension,
                m.DiscoveredBy,
                m.DiscoveryDate,
                BodyType = "Moon"
            });
        }
        public static IEnumerable<object> TransformListOfAsteroidsToListOfObjects(this IEnumerable<Asteroid> asteroids)
        {
            return asteroids.Select(m => new
            {
                Id = m.AsteroidId,
                m.Name,
                m.VolValue,
                m.MassValue,
                m.Dimension,
                m.DiscoveredBy,
                m.DiscoveryDate,
                BodyType = "Asteroid"
            });
        }
        public static IEnumerable<object> TransformListOfPlanetsToListOfObjects(this IEnumerable<Planet> planets)
        {
            return planets.Select(m => new
            {
                Id = m.PlanetId,
                m.Name,
                m.VolValue,
                m.MassValue,
                m.Dimension,
                m.DiscoveredBy,
                m.DiscoveryDate,
                BodyType = "Planet"
            });
        }
        public static IEnumerable<object> TransformListOfCometsToListOfObjects(this IEnumerable<Comet> comets)
        {
            return comets.Select(m => new
            {
                Id = m.CometId,
                m.Name,
                m.VolValue,
                m.MassValue,
                m.Dimension,
                m.DiscoveredBy,
                m.DiscoveryDate,
                BodyType = "Comet"
            });
        }
        public static IEnumerable<object> TransformListOfStarsToListOfObjects(this IEnumerable<Star> stars)
        {
            return stars.Select(m => new
            {
                Id = m.StarId,
                m.Name,
                m.VolValue,
                m.MassValue,
                m.Dimension,
                m.DiscoveredBy,
                m.DiscoveryDate,
                BodyType = "Star"
            });
        }
    }
}
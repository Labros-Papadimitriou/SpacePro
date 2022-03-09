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
                Name = m.Name,
                VolValue = m.VolValue,
                MassValue = m.MassValue,
                Dimension = m.Dimension,
                DiscoveredBy = m.DiscoveredBy,
                DiscoveryDate = m.DiscoveryDate,
                BodyType = "Moon"
            });
        } 
        public static IEnumerable<object> TransformListOfAsteroidsToListOfObjects(this IEnumerable<Asteroid> asteroids)
        {
            return asteroids.Select(m => new
            {
                Id = m.AsteroidId,
                Name = m.Name,
                VolValue = m.VolValue,
                MassValue = m.MassValue,
                Dimension = m.Dimension,
                DiscoveredBy = m.DiscoveredBy,
                DiscoveryDate = m.DiscoveryDate,
                BodyType = "Asteroid"
            });
        } 
        public static IEnumerable<object> TransformListOfPlanetsToListOfObjects(this IEnumerable<Planet> planets)
        {
            return planets.Select(m => new
            {
                Id = m.PlanetId,
                Name = m.Name,
                VolValue = m.VolValue,
                MassValue = m.MassValue,
                Dimension = m.Dimension,
                DiscoveredBy = m.DiscoveredBy,
                DiscoveryDate = m.DiscoveryDate,
                BodyType = "Planet"
            });
        }
        public static IEnumerable<object> TransformListOfCometsToListOfObjects(this IEnumerable<Comet> comets)
        {
            return comets.Select(m => new
            {
                Id = m.CometId,
                Name = m.Name,
                VolValue = m.VolValue,
                MassValue = m.MassValue,
                Dimension = m.Dimension,
                DiscoveredBy = m.DiscoveredBy,
                DiscoveryDate = m.DiscoveryDate,
                BodyType = "Comet"
            });
        } 
        public static IEnumerable<object> TransformListOfStarsToListOfObjects(this IEnumerable<Star> stars)
        {
            return stars.Select(m => new
            {
                Id = m.StarId,
                Name = m.Name,
                VolValue = m.VolValue,
                MassValue = m.MassValue,
                Dimension = m.Dimension,
                DiscoveredBy = m.DiscoveredBy,
                DiscoveryDate = m.DiscoveryDate,
                BodyType = "Star"
            });
        }
    }
}
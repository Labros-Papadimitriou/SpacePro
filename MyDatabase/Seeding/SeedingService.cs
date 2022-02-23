using Entities.Bodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Seeding
{
    public class SeedingService
    {
        ApplicationDbContext db;

        public SeedingService(ApplicationDbContext context)
        {
            db = context;
        }

        public void SeedPlanets()
        {
            Planet p1 = new Planet() { Name = "Mercury" };
            Planet p2 = new Planet() { Name = "Venus" };
            Planet p3 = new Planet() { Name = "Earth" };
            IList<Planet> planets = new List<Planet> { p1, p2, p3 };

            db.Planets.AddRange(planets);
            db.SaveChanges();

        }
    }
}

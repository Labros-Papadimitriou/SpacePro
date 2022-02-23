using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyDatabase.Seeding;

namespace MyDatabase.Initializers
{
    public class MockupDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    { 
        protected override void Seed(ApplicationDbContext context)
        {
            SeedingService service = new SeedingService(context);
            service.SeedPlanets();

            base.Seed(context);
        }
    }
}

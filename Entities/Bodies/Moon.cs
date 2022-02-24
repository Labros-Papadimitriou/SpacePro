using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Bodies
{
    public class Moon
    {
        public int MoonId { get; set; }
        public string Name { get; set; }
        public decimal? Mass { get; set; }
        [Display(Name = "Mass")]
        public decimal? MassValue { get; set; }
        [Display(Name = "Volume")]
        public decimal? VolValue { get; set; }

        public string DiscoveredBy { get; set; }
        public DateTime? DiscoveryDate { get; set; }
        //public int PlanetId { get; set; }
        //public Planet AroundPlanet { get; set; }
    }
}

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
        public Moon()
        {
            BodyImages = new HashSet<BodyImage>();
        }
        public int MoonId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Mass")]
        public decimal? MassValue { get; set; }
        [Display(Name = "Volume")]
        public decimal? VolValue { get; set; }

        public string DiscoveredBy { get; set; }
        public DateTime? DiscoveryDate { get; set; }

        //Foreign Keys
        public int PlanetId { get; set; }

        //Navigation Properties
        public Planet Planet { get; set; }
        public ICollection<BodyImage> BodyImages { get; set; }

    }
}

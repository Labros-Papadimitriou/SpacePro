using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Bodies
{
    public class Planet
    {
        //public Planet()
        //{
        //    Moons = new HashSet<Moon>();
        //}
        //[Required]
        //[ForeignKey("Moon")]
        public int PlanetId { get; set; }
        //[Required]
        public string Name { get; set; }
        [Display(Name ="Mass")]
        public decimal? MassValue { get; set; }
        [Display(Name = "Volume")]
        public decimal? VolValue { get; set; }
        public string Dimension { get; set; }

        public string DiscoveredBy { get; set; }
        public DateTime? DiscoveryDate { get; set; }
        //public ICollection<Moon> Moons { get; set; }
    }
}

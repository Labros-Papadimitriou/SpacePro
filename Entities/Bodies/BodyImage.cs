using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Bodies
{
    public class BodyImage
    {
        public int BodyImageId { get; set; }

        [Required(ErrorMessage = "Image URL is needed!")]
        [Display(Name = "Image URL")]
        public string Url { get; set; }

        [Required]
        public string AlternativeText { get; set; }

        //Foreign Keys
        public int? PlanetId { get; set; }
        public int? MoonId { get; set; }
        public int? CometId { get; set; }
        public int? StarId { get; set; }
        public int? AsteroidId { get; set; }

        //Navigation Properties
        public Planet Planet { get; set; }
        public Moon Moon { get; set; }
        public Comet Comet { get; set; }
        public Star Star { get; set; }
        public Asteroid Asteroid { get; set; }
    }
}

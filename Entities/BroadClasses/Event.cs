using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BroadClasses
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        //[Required]
        //public string Description { get; set; }

        //[Required]
        //public DateTime AwardDate { get; set; }
    }
}

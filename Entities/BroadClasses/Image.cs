using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BroadClasses
{
    public class Image
    {
        public int ImageId { get; set; }

        [Required(ErrorMessage = "Image URL is needed!")]
        [Display(Name = "Image URL")]
        public string Url { get; set; }
    }
}

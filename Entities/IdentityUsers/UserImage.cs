using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityUsers
{
    public class UserImage
    {
        public int UserImageId { get; set; }

        [Required(ErrorMessage = "Image URL is needed!")]
        [Display(Name = "Image URL")]
        public string Url { get; set; }

        [Required]
        public string AlternativeText { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}

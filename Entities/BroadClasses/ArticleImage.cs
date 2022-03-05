using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BroadClasses
{
    public class ArticleImage
    {
        public int ArticleImageId { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Image URL is needed!")]
        [Display(Name = "Image URL")]
        public string Url { get; set; }

        [Required]
        public string AlternativeText { get; set; }

        public Article Article { get; set; }
    }
}

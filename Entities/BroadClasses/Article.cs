using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BroadClasses
{
    public class Article
    {
        //public Article()
        //{
        //    PostDate = DateTime.Now;
        //}

        public int ArticleId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Title { get; set; }

        //[Required]
        //[MinLength(10000)]
        //public string Description { get; set; }

        //[Display(Name = "Date Posted")]
        //public DateTime PostDate { get; private set; }

        //[Display(Name = "Post Likes")]
        //public int? PostLikes { get; set; }

        ////Navigation Properties
        //[Display(Name = "Category")]
        //public ArticleCategory ArticleCategory { get; set; }

        //public Image Image { get; set; }
    }
}

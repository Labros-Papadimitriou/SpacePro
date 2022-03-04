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
        public int ArticleId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        public string ShortDescription { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10000)]
        public string FullDescription { get; set; }

        [Display(Name = "Date Posted")]
        public DateTime PostDate { get; set; }

        [Display(Name = "Post Likes")]
        public int? PostLikes { get; set; }

        [Display(Name = "Article Author")]
        public string AuthorName { get; set; }

        //Foreign Keys
        public int ArticleCategoryId { get; set; }

        //Navigation Properties
        [Display(Name = "Category")]
        public ArticleCategory ArticleCategory { get; set; }

        [Display(Name = "Article Image")]
        public ArticleImage ArticleImage { get; set; }
    }
}

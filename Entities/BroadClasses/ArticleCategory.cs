using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BroadClasses
{
    public class ArticleCategory
    {
        public ArticleCategory()
        {
            Articles = new HashSet<Article>();
        }

        public int ArticleCategoryId { get; set; }

        [Required(ErrorMessage = "Title is needed!")]
        [Display(Name = "Article Category")]
        public string Title { get; set; }

        //Navigation Properties
        public ICollection<Article> Articles { get; set; }
    }
}

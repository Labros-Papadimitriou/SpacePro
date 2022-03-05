using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacePro.Models.Dtos
{
    public class CreateArticleDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string AuthorName { get; set; }

        public int ArticleCategoryId { get; set; }

        public string ArticleImage { get; set; }
    }
}
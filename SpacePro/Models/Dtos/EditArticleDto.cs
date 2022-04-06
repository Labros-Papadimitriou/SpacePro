using Entities.BroadClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacePro.Models.Dtos
{
    public class EditArticleDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string AuthorName { get; set; }

        public int ArticleCategoryId { get; set; }

        public DateTime PostDate { get; set; } = DateTime.Now;

        public int PostLikes { get; set; }

        public ArticleImage ArticleImage { get; set; }
    }
}
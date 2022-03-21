using Entities.BroadClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityUsers
{
    public class ArticleLike
    {
        public int ArticleLikeId { get; set; }
        public string LikedUser { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}

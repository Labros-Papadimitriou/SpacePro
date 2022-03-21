using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityUsers
{
    public class PostLike
    {
        public int PostLikeId { get; set; } 
        public string LikedUser { get; set; }
        [ForeignKey("UserPost")]
        public int UserPostId { get; set; }
        public UserPost UserPost { get; set; }
    }
}

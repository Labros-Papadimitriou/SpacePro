using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityUsers
{
    public class UserPost
    {
        public UserPost()
        {
            PostLikes = new HashSet<PostLike>();
        }
        public int UserPostId { get; set; }

        public string PostDetails { get; set; }

        public int? PostLikesCount { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUser_id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }

    }
}

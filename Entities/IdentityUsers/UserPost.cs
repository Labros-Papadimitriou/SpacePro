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
        public int UserPostId { get; set; }

        public string PostDetails { get; set; }

        public int? PostLikes { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}

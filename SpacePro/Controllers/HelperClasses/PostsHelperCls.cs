using Entities.IdentityUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacePro.Controllers.HelperClasses
{
    public static class PostsHelperCls
    {
        public static IEnumerable<object> ObjectifyPosts(this IEnumerable<UserPost> posts)
        {
           return posts.Select(x => new {
                 x.UserPostId,
                 x.PostDetails,
                 x.PostLikesCount,
                 x.ApplicationUser_id,
                 PostLikes = x.PostLikes
                .Select(a => new { a.LikedUser, a.UserPostId })
             });
        }
    }
}
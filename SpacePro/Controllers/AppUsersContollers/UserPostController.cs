using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.AppUsersContollers
{
    public class UserPostController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public UserPostController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        // GET: UserPost
        [HttpGet]

        public ActionResult GetPosts(string id)
        {
            var posts = unitOfWork.UserPosts.GetPostWithLikes()
                .Where(p => p.ApplicationUser_id == id)
                .Select(x => new { x.UserPostId, x.PostDetails, x.PostLikesCount, x.ApplicationUser_id, PostLikes = x.PostLikes.Select(a => new { a.LikedUser, a.UserPostId }) });

            return Json(new { data = posts }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]

        public ActionResult AddOrRemoveLike(int postId, string userId)
        {
            var likess = unitOfWork.Likes.GetUserPostsLikes(postId);

            if (likess.Any(x => x.LikedUser.Equals(userId)))
            {

                var oldLike = likess.Where(x => x.LikedUser == userId && x.UserPostId == postId).First();
                unitOfWork.Likes.Remove(oldLike);

                unitOfWork.Complete();
                return Json(new { data = oldLike, text = "like removed" }, JsonRequestBehavior.AllowGet);
            }

            PostLike like = new PostLike();
            like.LikedUser = userId;
            like.UserPostId = postId;

            unitOfWork.Likes.Add(like);
            unitOfWork.Complete();

            return Json(new { data = like, text = "Like added" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPost(int UserPostId)
        {
            var post = unitOfWork.UserPosts.Get(UserPostId);

            return Json(new { data = post }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreatePost(string postDetails)
        {
            UserPost post = new UserPost();

            var userId = User.Identity.GetUserId();

            post.ApplicationUser_id = userId;
            post.PostDetails = postDetails;
            post.PostLikesCount = 0;
            unitOfWork.UserPosts.Add(post);
            unitOfWork.Complete();
            return Json(post);
        }
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var post = unitOfWork.UserPosts.Get(id);
            unitOfWork.UserPosts.Remove(post);
            unitOfWork.Complete();

            return Json(post);
        }

        [HttpPost]
        public ActionResult EditPost(int id, string postDetails)
        {
            var post = unitOfWork.UserPosts.Get(id);
            post.PostDetails = postDetails;
            unitOfWork.UserPosts.ModifyEntity(post);
            unitOfWork.Complete();
            return Json(post);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
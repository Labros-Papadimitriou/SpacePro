using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using MyDatabase;
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
        private ApplicationDbContext db;
        public UserPostController()
        {
            db = new ApplicationDbContext();
        }
        // GET: UserPost
        [HttpGet]

        public ActionResult GetPosts()
        {
            var userId = User.Identity.GetUserId();
            var posts = db.Users.Where(x => x.Id == userId).Select(x => x.UserPosts).ToList();
            //var posts = db.UserPosts.ToList();
            return Json(new { data = posts }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreatePost(string postDetails)
        {
            UserPost post = new UserPost();
            var user = db.Users.Find(User.Identity.GetUserId());
            post.ApplicationUser = user;
            post.PostDetails = postDetails;
            post.PostLikes = 0;
            db.Entry(post).State = EntityState.Added;
            db.SaveChanges();
            return Json(post);
        }
    }
}
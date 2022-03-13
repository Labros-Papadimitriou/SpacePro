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
        private readonly ApplicationDbContext db;
        public UserPostController()
        {
            db = new ApplicationDbContext();
        }
        // GET: UserPost
        [HttpGet]

        public ActionResult GetPosts()
        {
            var userId = User.Identity.GetUserId();

            var posts = db.UserPosts
                .Where(p=>p.ApplicationUser_id == userId)
                .Select(x=>new { x.UserPostId, x.PostDetails, x.PostLikes ,x.ApplicationUser_id});

            return Json(new { data = posts }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPost(int UserPostId)
        {
            var post = db.UserPosts
                .Where(p => p.UserPostId == UserPostId)
                .SingleOrDefault();

            return Json(new { data = post }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreatePost(string postDetails)
        {
            UserPost post = new UserPost();

            var userId = User.Identity.GetUserId();

            post.ApplicationUser_id = userId;
            post.PostDetails = postDetails;
            post.PostLikes = 0;
            db.Entry(post).State = EntityState.Added;
            db.SaveChanges();
            return Json(post);
        }
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var post = db.UserPosts.Find(id);
            db.Entry(post).State = EntityState.Deleted;
            db.SaveChanges();

            return Json(post);
        }
        [HttpPost]
        public ActionResult EditPost(int id, string postDetails)
        {
            var post = db.UserPosts.Find(id);
            post.PostDetails = postDetails;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return Json(post);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
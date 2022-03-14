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
        private readonly UnitOfWork unitOdWork;
        public UserPostController()
        {
            unitOdWork =new UnitOfWork(new ApplicationDbContext());
        }
        // GET: UserPost
        [HttpGet]

        public ActionResult GetPosts()
        {
            var userId = User.Identity.GetUserId();

            var posts = unitOdWork.UserPosts.GetAll()
                .Where(p=>p.ApplicationUser_id == userId)
                .Select(x=>new { x.UserPostId, x.PostDetails, x.PostLikes ,x.ApplicationUser_id});

            return Json(new { data = posts }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPost(int UserPostId)
        {
            var post = unitOdWork.UserPosts.Get(UserPostId);

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
            unitOdWork.UserPosts.Add(post);
            unitOdWork.Complete();
            return Json(post);
        }
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var post = unitOdWork.UserPosts.Get(id);
            unitOdWork.UserPosts.Remove(post);
            unitOdWork.Complete();

            return Json(post);
        }

        [HttpPost]
        public ActionResult EditPost(int id, string postDetails)
        {
            var post = unitOdWork.UserPosts.Get(id);
            post.PostDetails = postDetails;
            unitOdWork.UserPosts.ModifyEntity(post);
            unitOdWork.Complete();
            return Json(post);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOdWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
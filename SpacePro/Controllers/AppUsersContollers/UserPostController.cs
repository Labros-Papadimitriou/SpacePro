﻿using Entities.IdentityUsers;
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
            var user = db.Users.Find(userId);

            var posts = db.UserPosts.Where(p=>p.ApplicationUser_id == userId).Select(x=>new { x.UserPostId, x.PostDetails, x.PostLikes ,x.ApplicationUser_id});
            //var posts = db.UserPosts.ToList();


            return Json(new { data = posts }, JsonRequestBehavior.AllowGet);
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